using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class ObjectClickSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // 自动获取AudioSource组件
        audioSource = GetComponent<AudioSource>();

        // 确保Collider设置为触发器模式（可选）
        // GetComponent<Collider2D>().isTrigger = true;
    }

    // 鼠标点击检测方法一：使用OnMouseDown
    private void OnMouseDown()
    {
        // 检查是否暂停游戏（可选）
        if (Time.timeScale < 0.1f) return;

        PlaySound();
    }

    // 方法二：使用射线检测（推荐，兼容性更好）
    /*
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if(hit.collider != null && hit.collider.gameObject == gameObject)
            {
                PlaySound();
            }
        }
    }
    */

    void PlaySound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            // 避免声音重叠播放
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("AudioSource未设置或缺少音频文件！", gameObject);
        }
    }
}