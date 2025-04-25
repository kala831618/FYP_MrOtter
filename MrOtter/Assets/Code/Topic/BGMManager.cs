using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager _instance;
    private AudioSource audioSource;

    void Awake()
    {
        // 單例模式檢查
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        // 綁定場景加載事件
        SceneManager.sceneLoaded += OnSceneLoaded;

        // 初始播放
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        // 判斷是否為允許播放的場景
        if (sceneName == "Topic" || sceneName == "Topic_Food")
        {
            // 如果音樂已停止，重新播放
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // 非指定場景時，停止並自我銷毀
            audioSource.Stop();
            DestroyBGMInstance();
        }
    }

    // 專門處理銷毀的邏輯
    private void DestroyBGMInstance()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(gameObject);
        _instance = null; // 重要！重置單例引用
    }

    void OnDestroy()
    {
        // 確保取消事件綁定
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}