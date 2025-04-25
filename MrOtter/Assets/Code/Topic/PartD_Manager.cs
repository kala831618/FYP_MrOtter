using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PartD_Manager : MonoBehaviour
{
    [Header("�˼Ƴ]�w")]
    public Text countdownText2;
    public string nextPartName = "PartE";

    // �ݭn�n����L���n�ܼ�
    private Coroutine countdownRoutine;
    private int currentCount = 5;

    void OnEnable()
    {
        // �ݭn��l�ƭ˼ƪ��{���X
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
            countdownText2.text = currentCount.ToString();
            yield return new WaitForSeconds(1f);
            currentCount--;
        }
        FinishPart();
    }

    void FinishPart()
    {
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

    // �ץ����I�G�����h�l����A���å��T�w�q��k
    public void OnContinueClicked()
    {
        StopAllCoroutines();
        TopicManager.Instance.SwitchPart(4);
    }
}