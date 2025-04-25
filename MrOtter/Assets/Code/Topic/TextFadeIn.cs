using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    public float fadeDuration = 2f;
    public float floatDistance = 50f;
    private Text textComponent; // 正確定義的變量名
    private Vector3 startPos;
    private float timer = 0f;

    void Start()
    {
        textComponent = GetComponent<Text>(); // 正確獲取 Text 組件
        startPos = transform.localPosition;
        transform.localPosition = startPos - new Vector3(0, floatDistance, 0);
        textComponent.color = new Color(
            textComponent.color.r,
            textComponent.color.g,
            textComponent.color.b,
            0
        );
    }

    void Update()
    {
        timer += Time.deltaTime;
        float progress = Mathf.Clamp01(timer / fadeDuration);

        // 修正：使用 textComponent 而非 text
        textComponent.color = new Color(
            textComponent.color.r,
            textComponent.color.g,
            textComponent.color.b,
            progress
        );

        transform.localPosition = Vector3.Lerp(
            startPos - new Vector3(0, floatDistance, 0),
            startPos,
            progress
        );
    }
}