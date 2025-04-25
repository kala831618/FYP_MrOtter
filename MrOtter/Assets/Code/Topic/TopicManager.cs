using UnityEngine;
using UnityEngine.SceneManagement;

public class TopicManager : MonoBehaviour
{
    public static TopicManager Instance;
    public GameObject[] parts;
    public SpriteRenderer otterSprite;

    void Awake()
    {
        Instance = this;
        InitializeParts();
    }

    void InitializeParts()
    {
        foreach (var part in parts) part.SetActive(false);
        if (parts.Length > 0) parts[0].SetActive(true);
    }

    public void SwitchPart(int partIndex)
    {
        bool showOtter = partIndex != 4; // PartE是索引4
        UpdateOtterVisibility(showOtter);

        foreach (var part in parts) part.SetActive(false);
        parts[partIndex].SetActive(true);
    }

    // 新增的方法 ▼▼▼
    public void SwitchToPartD()
    {
        int index = System.Array.FindIndex(parts, p => p.name == "PartD");
        SwitchPart(index);
    }

    void UpdateOtterVisibility(bool show)
    {
        if (otterSprite != null)
        {
            otterSprite.enabled = show;
        }
    }
}