// OtterDialogue.cs
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 改用 UnityEngine.UI

public class OtterDialogue : MonoBehaviour
{
    [SerializeField] private string[] dialogues;
    [SerializeField] private Text dialogueText; // 改回標準 Text
    [SerializeField] private GameObject computer;

    private int currentIndex;
    private bool firstDialogueDone;

    void Start()
    {
        StartCoroutine(AutoPlayDialogue());
    }

    private IEnumerator AutoPlayDialogue()
    {
        while (true)
        {
            dialogueText.text = dialogues[currentIndex];
            yield return new WaitForSeconds(3f);

            if (!firstDialogueDone && currentIndex == dialogues.Length - 1)
            {
                computer.GetComponent<Animator>().SetBool("Blink", true);
                firstDialogueDone = true;
            }

            currentIndex = (currentIndex + 1) % dialogues.Length;
        }
    }
}