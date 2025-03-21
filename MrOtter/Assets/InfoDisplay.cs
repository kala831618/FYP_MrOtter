using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public GameObject infoPanel; // ��T�� GameObject
    public Button logoButton; // ���s���ޥ�

    void Start()
    {
        logoButton.onClick.AddListener(ToggleInfoPanel);
        infoPanel.SetActive(false); // �T�O�}�l�ɸ�T��O���ê�
    }

    void ToggleInfoPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf); // ������T����ܪ��A
    }
}