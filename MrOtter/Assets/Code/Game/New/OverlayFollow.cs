using UnityEngine;
using UnityEngine.UI;

public class OverlayFollow : MonoBehaviour
{
    [Header("綁定設定")]
    public Transform target;          // 角色 Transform
    public Vector3 screenOffset = new Vector3(0, 50f, 0); // 屏幕空間偏移量

    [Header("進階設定")]
    public float smoothSpeed = 5f;    // 平滑移動速度
    public bool clampToScreen = true; // 防止文字超出畫面
    public float screenMargin = 50f;  // 邊界留空距離

    private RectTransform rectTransform;
    private Camera mainCamera;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (target == null || mainCamera == null) return;

        // 將角色的世界座標轉換為屏幕座標
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        // 如果目標在攝影機後方，強制隱藏文字
        if (screenPos.z < 0)
        {
            rectTransform.anchoredPosition = Vector2.one * -1000; // 移出畫面
            return;
        }

        // 限制在屏幕範圍內（可選）
        if (clampToScreen)
        {
            screenPos.x = Mathf.Clamp(
                screenPos.x,
                screenMargin,
                Screen.width - screenMargin
            );
            screenPos.y = Mathf.Clamp(
                screenPos.y,
                screenMargin,
                Screen.height - screenMargin
            );
        }

        // 添加偏移量並平滑移動
        Vector2 targetPos = (Vector2)screenPos + (Vector2)screenOffset;
        rectTransform.anchoredPosition = Vector2.Lerp(
            rectTransform.anchoredPosition,
            targetPos,
            smoothSpeed * Time.deltaTime
        );
    }
}