using UnityEngine;

public class ClickToHideMultipleTexts : MonoBehaviour
{
    [Header("需要隱藏的文字物件")]
    [Tooltip("將所有需要隱藏的Text物件拖曳至此陣列")]
    public GameObject[] targetTexts; // 多個文字物件的陣列

    [Header("點擊設置")]
    [SerializeField] private bool disableAfterClick = true; // 點擊後是否禁用腳本
    [SerializeField] private float delayBeforeHide = 0f;    // 隱藏前的延遲時間

    private void OnMouseDown()
    {
        if (Time.timeScale < 0.1f) return; // 檢測遊戲暫停

        StartCoroutine(HideTextsWithDelay());
    }

    System.Collections.IEnumerator HideTextsWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeHide);

        foreach (GameObject text in targetTexts)
        {
            if (text != null)
            {
                text.SetActive(false);
            }
            else
            {
                Debug.LogWarning("陣列中存在未設置的文字物件！", gameObject);
            }
        }

        if (disableAfterClick)
        {
            enabled = false; // 禁用腳本防止再次觸發
            GetComponent<Collider2D>().enabled = false; // 可選：禁用碰撞體
        }
    }

    // 進階：自動尋找帶標籤的文字物件
    [Header("自動尋找設置")]
    [SerializeField] private bool useTagSearch;
    [SerializeField] private string searchTag = "HideableText";

    void Start()
    {
        if (useTagSearch)
        {
            targetTexts = GameObject.FindGameObjectsWithTag(searchTag);
            if (targetTexts.Length == 0)
            {
                Debug.LogError("找不到帶有標籤 " + searchTag + " 的物件！");
            }
        }
    }
}