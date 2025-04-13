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
            // �����N UI �w���ؼЪ���W��
            rectTransform.position = target.position + offset;
        }
    }
}