using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // 必須引用此命名空間

public class To_TopicFood : MonoBehaviour
{
    [SerializeField] private AudioClip transitionSound;
    [SerializeField] private string targetSceneName = "Topic_Food";
    [SerializeField] private float sceneSwitchDelay = 0.5f;

    private AudioSource audioSource;
    private bool isClickable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!isClickable) return;
        StartCoroutine(PlaySoundAndSwitchScene());
    }

    // 協程必須返回 IEnumerator 類型
    private IEnumerator PlaySoundAndSwitchScene()
    {
        isClickable = false;

        if (audioSource != null && transitionSound != null)
        {
            audioSource.PlayOneShot(transitionSound);
        }

        yield return new WaitForSeconds(sceneSwitchDelay);

        SceneManager.LoadScene(targetSceneName);
    }
}