using UnityEngine;

public class PartA_Manager : MonoBehaviour

{
    // ��Sprite�Q�I���ɩI�s
    private void OnMouseDown()
    {
        // �q��GameManager������PartB
        TopicManager.Instance.SwitchPart(1);
    }

    public void SwitchPart(int partIndex)
    {
        Debug.Log($"������ Part {partIndex}");
        // ...�즳�{���X...
    }


}