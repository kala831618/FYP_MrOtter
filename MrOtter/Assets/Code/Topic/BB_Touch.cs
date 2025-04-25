using UnityEngine;

public class BB_Touch : MonoBehaviour
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
            animator.SetTrigger("PlayAnimationA");
        }

        if (audioSource != null && clickSound != null)
        {
            // ����@���ʭ��ġ]�קK���_��e����^
            audioSource.PlayOneShot(clickSound);
        }
    }
}