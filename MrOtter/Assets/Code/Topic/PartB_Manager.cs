using UnityEngine;
using System.Collections;
using UnityEngine.UI; // 穝糤硂︽

public class PartB_Manager : MonoBehaviour
{
    [Header("计砞﹚")]
    public Text countdownText; // эノUI Text

    [Header("ち传砞﹚")]
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
        FinishPart(); // 计挡笆ち传
    }

    void UpdateCountdownText()
    {
        countdownText.text = currentCount.ToString();

        // 匡程1陪ボ"GO!"
        if (currentCount == 0) countdownText.text = "GO!";
    }

    public void OnContinueClicked()
    {
        StopCoroutine(countdownRoutine);
        FinishPart();
    }

    void FinishPart()
    {
        // 玂Τち传呸胯
        foreach (var part in TopicManager.Instance.parts)
        {
            if (part.name == nextPartName)
            {
                int index = System.Array.IndexOf(TopicManager.Instance.parts, part);
                TopicManager.Instance.SwitchPart(index);
                return;
            }
        }
        Debug.LogError($"тぃ {nextPartName} ン");
    }
}