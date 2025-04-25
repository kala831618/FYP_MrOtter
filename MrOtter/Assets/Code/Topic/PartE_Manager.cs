using UnityEngine;
using UnityEngine.SceneManagement;

public class PartE_Manager : MonoBehaviour
{
    [Header("場景設定")]
    public string targetScene = "Topic";

    void OnEnable()
    {
        SetupFullscreenCollider();
    }

    void SetupFullscreenCollider()
    {
        // 添加全屏碰撞體
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(Camera.main.orthographicSize * 2 * Camera.main.aspect,
                                  Camera.main.orthographicSize * 2);
    }

    void OnMouseDown()
    {
        LoadTargetScene();
    }

    public void LoadTargetScene()
    {
        try
        {
            SceneManager.LoadScene(targetScene);
        }
        catch
        {
            Debug.LogError($"場景 {targetScene} 加載失敗！");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}