using UnityEngine;

public class ContinueButton_PartD : MonoBehaviour
{
    void OnMouseDown()
    {
        // 安全檢查管理器是否存在
        PartD_Manager manager = FindObjectOfType<PartD_Manager>();
        if (manager != null)
        {
            manager.OnContinueClicked();
        }
        else
        {
            Debug.LogError("找不到 PartD_Manager!");
        }

    }
}