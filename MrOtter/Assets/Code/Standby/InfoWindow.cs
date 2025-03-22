using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    // �N��T�� GameObject ���o��
    public GameObject infoPanel;

    // ����s�Q�I���ɽեγo�Ӥ�k
    public void ToggleInfoPanel()
    {
        // ������T����ܪ��A
        if (infoPanel != null)
        {
            infoPanel.SetActive(!infoPanel.activeSelf);
        }
        else
        {
            Debug.LogError("Info panel is not assigned in the inspector.");
        }
    }
}