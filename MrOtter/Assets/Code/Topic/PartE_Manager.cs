using UnityEngine;
using UnityEngine.SceneManagement;

public class PartE_Manager : MonoBehaviour
{
    [Header("�����]�w")]
    public string targetScene = "Topic";

    void OnEnable()
    {
        SetupFullscreenCollider();
    }

    void SetupFullscreenCollider()
    {
        // �K�[���̸I����
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
            Debug.LogError($"���� {targetScene} �[�����ѡI");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}