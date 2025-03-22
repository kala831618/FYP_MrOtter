using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public GameObject infoPanel; // 資訊表的 GameObject
    public Button logoButton; // 按鈕的引用

    void Start()
    {
        logoButton.onClick.AddListener(ToggleInfoPanel);
        infoPanel.SetActive(false); // 確保開始時資訊表是隱藏的
    }

    void ToggleInfoPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf); // 切換資訊表的顯示狀態
    }
}