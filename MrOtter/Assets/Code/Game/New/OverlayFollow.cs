using UnityEngine;
using UnityEngine.UI;

public class OverlayFollow : MonoBehaviour
{
    [Header("�j�w�]�w")]
    public Transform target;          // ���� Transform
    public Vector3 screenOffset = new Vector3(0, 50f, 0); // �̹��Ŷ������q

    [Header("�i���]�w")]
    public float smoothSpeed = 5f;    // ���Ʋ��ʳt��
    public bool clampToScreen = true; // �����r�W�X�e��
    public float screenMargin = 50f;  // ��ɯd�ŶZ��

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

        // �N���⪺�@�ɮy���ഫ���̹��y��
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        // �p�G�ؼЦb��v�����A�j�����ä�r
        if (screenPos.z < 0)
        {
            rectTransform.anchoredPosition = Vector2.one * -1000; // ���X�e��
            return;
        }

        // ����b�̹��d�򤺡]�i��^
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

        // �K�[�����q�å��Ʋ���
        Vector2 targetPos = (Vector2)screenPos + (Vector2)screenOffset;
        rectTransform.anchoredPosition = Vector2.Lerp(
            rectTransform.anchoredPosition,
            targetPos,
            smoothSpeed * Time.deltaTime
        );
    }
}