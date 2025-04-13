using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;      // UI Text����
    public string[] dialogues;     // �w�]�ܤ�10�y���
    public float showInterval = 5f; // �����ܶ��j
    public float displayTime = 3f; // ��ܫ���ɶ�

    void Start()
    {
        dialogues = new string[]
        {
            "���ѤѮ�u�n�I",
            "��ꩭn���h�H",
            "�{�l�n�j...�B�P�B�P",
            "�ڥi�H��u��?",
            "PolyU����s�~!",
            "�o�{�a�W�����I",
            "�p�ߤ����|�r�H�I",
            "��á�M��á�O���@�˪��I",
            "�u�@�֤F~���i�@�U~",
            "�ڤ]�Q�RPolyu�P���~"
        };

        StartCoroutine(ShowRandomDialogue());
    }

    IEnumerator ShowRandomDialogue()
    {
        while (true)
        {
            yield return new WaitForSeconds(showInterval);
            string randomDialogue = dialogues[Random.Range(0, dialogues.Length)];
            dialogueText.text = randomDialogue;
            yield return new WaitForSeconds(displayTime);
            dialogueText.text = "";
        }
    }
}