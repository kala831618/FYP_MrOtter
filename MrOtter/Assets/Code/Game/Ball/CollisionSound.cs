using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class CollisionSound : MonoBehaviour
{
    [Header("音效设置")]
    [SerializeField] private AudioClip collisionSound;
    [SerializeField][Range(0f, 1f)] private float volume = 1f;
    [SerializeField][Range(0.1f, 3f)] private float pitchRandomRange = 0.2f;

    [Header("碰撞过滤")]
    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private bool useTagFilter;
    [SerializeField] private string targetTag = "Untagged";

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 自动配置组件参数
        audioSource.playOnAwake = false;
        GetComponent<Collider2D>().isTrigger = false; // 默认使用普通碰撞器
    }

    // 普通物理碰撞版本
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CheckCollisionValid(collision.gameObject))
        {
            PlayCollisionSound();
        }
    }

    // 触发器版本（需要勾选Collider2D的isTrigger）
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckCollisionValid(other.gameObject))
        {
            PlayCollisionSound();
        }
    }

    bool CheckCollisionValid(GameObject other)
    {
        // 层级过滤
        if (collisionLayers != (collisionLayers | (1 << other.layer)))
        {
            return false;
        }

        // 标签过滤
        if (useTagFilter && !other.CompareTag(targetTag))
        {
            return false;
        }

        return true;
    }

    void PlayCollisionSound()
    {
        if (collisionSound == null)
        {
            Debug.LogWarning("未设置碰撞音效！", gameObject);
            return;
        }

        // 随机音调
        audioSource.pitch = Random.Range(1 - pitchRandomRange / 2, 1 + pitchRandomRange / 2);

        // 使用PlayOneShot允许多次声音叠加
        audioSource.PlayOneShot(collisionSound, volume);
    }
}