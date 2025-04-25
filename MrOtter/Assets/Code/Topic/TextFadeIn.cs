using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    public float fadeDuration = 2f;
    public float floatDistance = 50f;
    private Text textComponent; // ���T�w�q���ܶq�W
    private Vector3 startPos;
    private float timer = 0f;

    void Start()
    {
        textComponent = GetComponent<Text>(); // ���T��� Text �ե�
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

        // �ץ��G�ϥ� textComponent �ӫD text
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