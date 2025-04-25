using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // �����ޥΦ��R�W�Ŷ�

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

    // ��{������^ IEnumerator ����
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