using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PartD_Manager : MonoBehaviour
{
    [Header("倒數設定")]
    public Text countdownText2;
    public string nextPartName = "PartE";

    // 需要聲明其他必要變數
    private Coroutine countdownRoutine;
    private int currentCount = 5;

    void OnEnable()
    {
        // 需要初始化倒數的程式碼
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
        Debug.LogError($"找不到 {nextPartName} 物件！");
    }

    // 修正重點：移除多餘的花括號並正確定義方法
    public void OnContinueClicked()
    {
        StopAllCoroutines();
        TopicManager.Instance.SwitchPart(4);
    }
}