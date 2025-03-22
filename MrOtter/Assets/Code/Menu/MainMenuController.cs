using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void OnMouseDown()
    {
        // 根據圖片的名稱來判斷跳轉的場景
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