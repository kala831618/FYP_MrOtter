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

    // 使用 Unity 的點擊檢測（需 Collider2D）
    private void OnMouseDown()
    {
        if (animator != null)
        {
            // 觸發動畫（假設使用 Trigger 參數）
            animator.SetTrigger("PlayAnimationG");
        }

        if (audioSource != null && clickSound != null)
        {
            // 播放一次性音效（避免中斷當前播放）
            audioSource.PlayOneShot(clickSound);
        }
    }
}