using UnityEngine;

public class SimpleUIFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2f, 0);

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // 直接將 UI 定位到目標物件上方
            rectTransform.position = target.position + offset;
        }
    }
}