using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("綁定設定")]
    public Animator animator;      // 手動拖曳綁定或自動抓取
    public GameObject infoPanel;   // 手動拖曳你的UI面板到此欄位

    void Start()
    {
        // 自動抓取 Animator（如果沒手動綁定）
        if (animator == null) animator = GetComponent<Animator>();

        // 確保UI初始為關閉狀態
        if (infoPanel != null) infoPanel.SetActive(false);
    }

    void OnMouseDown()
    {
        // 停止閃爍動畫
        if (animator != null) animator.enabled = false;

        // 開啟資訊面板
        if (infoPanel != null) infoPanel.SetActive(true);
    }
}