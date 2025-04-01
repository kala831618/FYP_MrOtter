using UnityEngine;

public class ClickToHideMultipleTexts : MonoBehaviour
{
    [Header("�ݭn���ê���r����")]
    [Tooltip("�N�Ҧ��ݭn���ê�Text����즲�ܦ��}�C")]
    public GameObject[] targetTexts; // �h�Ӥ�r���󪺰}�C

    [Header("�I���]�m")]
    [SerializeField] private bool disableAfterClick = true; // �I����O�_�T�θ}��
    [SerializeField] private float delayBeforeHide = 0f;    // ���ëe������ɶ�

    private void OnMouseDown()
    {
        if (Time.timeScale < 0.1f) return; // �˴��C���Ȱ�

        StartCoroutine(HideTextsWithDelay());
    }

    System.Collections.IEnumerator HideTextsWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeHide);

        foreach (GameObject text in targetTexts)
        {
            if (text != null)
            {
                text.SetActive(false);
            }
            else
            {
                Debug.LogWarning("�}�C���s�b���]�m����r����I", gameObject);
            }
        }

        if (disableAfterClick)
        {
            enabled = false; // �T�θ}������A��Ĳ�o
            GetComponent<Collider2D>().enabled = false; // �i��G�T�θI����
        }
    }

    // �i���G�۰ʴM��a���Ҫ���r����
    [Header("�۰ʴM��]�m")]
    [SerializeField] private bool useTagSearch;
    [SerializeField] private string searchTag = "HideableText";

    void Start()
    {
        if (useTagSearch)
        {
            targetTexts = GameObject.FindGameObjectsWithTag(searchTag);
            if (targetTexts.Length == 0)
            {
                Debug.LogError("�䤣��a������ " + searchTag + " ������I");
            }
        }
    }
}