using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    // 將資訊表的 GameObject 拖到這裡
    public GameObject infoPanel;

    // 當按鈕被點擊時調用這個方法
    public void ToggleInfoPanel()
    {
        // 切換資訊表的顯示狀態
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