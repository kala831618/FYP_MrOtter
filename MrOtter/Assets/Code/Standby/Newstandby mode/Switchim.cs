using UnityEngine;
using UnityEngine.SceneManagement;

public class Switchim : MonoBehaviour
{
    // ������J�ؼг����W�١]�ݩM Build Settings �����W�٧����@�P�^
    public string targetSceneName;

    // ��k1�G���s�I����������
    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    // ��k2�G�I��Ĳ�o���������]�Ҧp���a�I�쪫��^
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �T�O�I����H�� "Player" ����
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}