using UnityEngine;

public class PartA_Manager : MonoBehaviour

{
    // 當Sprite被點擊時呼叫
    private void OnMouseDown()
    {
        // 通知GameManager切換到PartB
        TopicManager.Instance.SwitchPart(1);
    }

    public void SwitchPart(int partIndex)
    {
        Debug.Log($"切換到 Part {partIndex}");
        // ...原有程式碼...
    }


}