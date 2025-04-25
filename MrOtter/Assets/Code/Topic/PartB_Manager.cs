using UnityEngine;
using System.Collections;
using UnityEngine.UI; // �s�W�o��

public class PartB_Manager : MonoBehaviour
{
    [Header("�˼Ƴ]�w")]
    public Text countdownText; // ���UI Text

    [Header("�����]�w")]
    public string nextPartName = "PartC";

    private int currentCount = 5;
    private Coroutine countdownRoutine;

    void OnEnable()
    {
        currentCount = 5;
        UpdateCountdownText();
        StartCountdown();
    }

    void StartCountdown()
    {
        countdownRoutine = StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (currentCount > 0)
        {
            yield return new WaitForSeconds(1f);
            currentCount--;
            UpdateCountdownText();
        }
        FinishPart(); // �˼Ƶ�����۰ʤ���
    }

    void UpdateCountdownText()
    {
        countdownText.text = currentCount.ToString();

        // �i��G�̫�1�����"GO!"
        if (currentCount == 0) countdownText.text = "GO!";
    }

    public void OnContinueClicked()
    {
        StopCoroutine(countdownRoutine);
        FinishPart();
    }

    void FinishPart()
    {
        // �O���즳�����޿�
        foreach (var part in TopicManager.Instance.parts)
        {
            if (part.name == nextPartName)
            {
                int index = System.Array.IndexOf(TopicManager.Instance.parts, part);
                TopicManager.Instance.SwitchPart(index);
                return;
            }
        }
        Debug.LogError($"�䤣�� {nextPartName} ����I");
    }
}