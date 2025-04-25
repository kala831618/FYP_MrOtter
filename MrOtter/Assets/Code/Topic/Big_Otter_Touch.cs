using UnityEngine;

public class Big_Otter_Touch : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // �ϥ� Unity ���I���˴��]�� Collider2D�^
    private void OnMouseDown()
    {
        if (animator != null)
        {
            // Ĳ�o�ʵe�]���]�ϥ� Trigger �Ѽơ^
            animator.SetTrigger("PlayAnimationG");
        }

        if (audioSource != null && clickSound != null)
        {
            // ����@���ʭ��ġ]�קK���_��e����^
            audioSource.PlayOneShot(clickSound);
        }
    }
}