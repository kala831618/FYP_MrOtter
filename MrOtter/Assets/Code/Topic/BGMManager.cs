using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager _instance;
    private AudioSource audioSource;

    void Awake()
    {
        // ��ҼҦ��ˬd
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        // �j�w�����[���ƥ�
        SceneManager.sceneLoaded += OnSceneLoaded;

        // ��l����
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        // �P�_�O�_�����\���񪺳���
        if (sceneName == "Topic" || sceneName == "Topic_Food")
        {
            // �p�G���֤w����A���s����
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // �D���w�����ɡA����æۧھP��
            audioSource.Stop();
            DestroyBGMInstance();
        }
    }

    // �M���B�z�P�����޿�
    private void DestroyBGMInstance()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(gameObject);
        _instance = null; // ���n�I���m��Ҥޥ�
    }

    void OnDestroy()
    {
        // �T�O�����ƥ�j�w
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}