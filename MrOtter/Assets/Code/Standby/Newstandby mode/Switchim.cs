using UnityEngine;
using UnityEngine.SceneManagement;

public class Switchim : MonoBehaviour
{
    // 直接輸入目標場景名稱（需和 Build Settings 中的名稱完全一致）
    public string targetSceneName;

    // 方法1：按鈕點擊切換場景
    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    // 方法2：碰撞觸發切換場景（例如玩家碰到物件）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 確保碰撞對象有 "Player" 標籤
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}