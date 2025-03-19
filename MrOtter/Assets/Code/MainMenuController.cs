using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void OnMouseDown()
    {
        // �ھڹϤ����W�٨ӧP�_���઺����
        switch (gameObject.name)
        {
            case "ButtonA":
                SceneManager.LoadScene("Game");
                break;
            case "ButtonB":
                SceneManager.LoadScene("Topic");
                break;
            case "ButtonC":
                SceneManager.LoadScene("Standby");
                break;
        }
    }
}