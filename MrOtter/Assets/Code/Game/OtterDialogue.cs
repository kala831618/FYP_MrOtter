using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OtterDialogue : MonoBehaviour
{
    public enum GamePhase { PartA, PartB }

    [Header("Part A �]�w")]
    [SerializeField][TextArea] private string[] partADialogues;
    [SerializeField] private Text dialogueText;
    [SerializeField] private GameObject computer;

    [Header("Part B �]�w")]
    [SerializeField][TextArea] private string[] partBDialogues;
    [SerializeField] private float partBMinInterval = 2f;
    [SerializeField] private float partBMaxInterval = 5f;
    [SerializeField] private bool allowRepeatDialogue = true; // �w�]���\����

    private GamePhase currentPhase = GamePhase.PartA;
    private int currentIndex;
    private bool firstDialogueDone;
    private Coroutine dialogueCoroutine;
    private List<int> availableBDialogues = new List<int>();

    void Start()
    {
        InitializeBDialogues();
        StartPhaseBehavior();
    }

    void InitializeBDialogues()
    {
        availableBDialogues.Clear();
        for (int i = 0; i < partBDialogues.Length; i++)
        {
            availableBDialogues.Add(i);
        }
    }

    void StartPhaseBehavior()
    {
        if (dialogueCoroutine != null)
            StopCoroutine(dialogueCoroutine);

        dialogueCoroutine = currentPhase == GamePhase.PartA
            ? StartCoroutine(PartA_SequenceDialogue())
            : StartCoroutine(PartB_RandomDialogue());
    }

    IEnumerator PartA_SequenceDialogue()
    {
        while (currentPhase == GamePhase.PartA && partADialogues.Length > 0)
        {
            dialogueText.text = partADialogues[currentIndex];
            yield return new WaitForSeconds(3f);

            if (!firstDialogueDone && currentIndex == partADialogues.Length - 1)
            {
                computer.GetComponent<ComputerGameSimplified>()?.StartBlinking();
                firstDialogueDone = true;
            }

            currentIndex = (currentIndex + 1) % partADialogues.Length;
        }
    }

    IEnumerator PartB_RandomDialogue()
    {
        while (currentPhase == GamePhase.PartB)
        {
            if (partBDialogues.Length == 0) yield break;

            int randomIndex = GetValidDialogueIndex();
            dialogueText.text = partBDialogues[randomIndex];

            UpdateAvailableDialogues(randomIndex);

            yield return new WaitForSeconds(Random.Range(partBMinInterval, partBMaxInterval));
        }
    }

    int GetValidDialogueIndex()
    {
        if (allowRepeatDialogue || availableBDialogues.Count == 0)
        {
            return Random.Range(0, partBDialogues.Length);
        }

        int listIndex = Random.Range(0, availableBDialogues.Count);
        return availableBDialogues[listIndex];
    }

    void UpdateAvailableDialogues(int usedIndex)
    {
        if (!allowRepeatDialogue)
        {
            availableBDialogues.Remove(usedIndex);
            if (availableBDialogues.Count == 0)
            {
                InitializeBDialogues();
                Debug.Log("PartB��ܤw���m�A�}�l�s�@������");
            }
        }
    }

    public void SwitchToPartB()
    {
        currentPhase = GamePhase.PartB;
        InitializeBDialogues();
        StartPhaseBehavior();
        Debug.Log("�w������PartB�����ܼҦ�");
    }

    public void StopDialogues()
    {
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
        }
    }

    public bool IsPartACompleted => firstDialogueDone;
}