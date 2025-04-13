using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("�j�w�]�w")]
    public Animator animator;      // ��ʩ즲�j�w�Φ۰ʧ��
    public GameObject infoPanel;   // ��ʩ즲�A��UI���O�즹���

    void Start()
    {
        // �۰ʧ�� Animator�]�p�G�S��ʸj�w�^
        if (animator == null) animator = GetComponent<Animator>();

        // �T�OUI��l���������A
        if (infoPanel != null) infoPanel.SetActive(false);
    }

    void OnMouseDown()
    {
        // ����{�{�ʵe
        if (animator != null) animator.enabled = false;

        // �}�Ҹ�T���O
        if (infoPanel != null) infoPanel.SetActive(true);
    }
}