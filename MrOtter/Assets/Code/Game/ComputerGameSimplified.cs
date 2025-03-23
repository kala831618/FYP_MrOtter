using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComputerGameSimplified : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject computerUI;
    [SerializeField] private Image clockInButton;
    [SerializeField] private Image confirmButton;
    [SerializeField] private Image successImage;

    [Header("Animation")]
    [SerializeField] private Animator computerAnimator;
    [SerializeField] private string blinkParam = "Blink";

    private bool canInteract = false;
    private BoxCollider2D interactionCollider;

    void Start()
    {
        InitializeComponents();
        ResetUI();
    }

    void InitializeComponents()
    {
        // 自動添加必要組件
        interactionCollider = GetComponent<BoxCollider2D>();
        if (interactionCollider == null)
        {
            interactionCollider = gameObject.AddComponent<BoxCollider2D>();
            interactionCollider.isTrigger = true;
        }

        // 安全獲取Animator
        if (computerAnimator == null)
            computerAnimator = GetComponent<Animator>();
    }

    void ResetUI()
    {
        computerUI.SetActive(false);
        clockInButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);
        successImage.gameObject.SetActive(false);
        ResetCanvasGroup();
    }

    void ResetCanvasGroup()
    {
        if (confirmButton.TryGetComponent<CanvasGroup>(out var cg))
        {
            cg.alpha = 1;
            cg.interactable = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero
            );

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OpenComputerInterface();
            }
        }
    }

    public void StartBlinking()
    {
        canInteract = true;
        computerAnimator.SetBool(blinkParam, true);
        interactionCollider.enabled = true;
        Debug.Log("電腦開始閃爍");
    }

    public void OnClockInButtonClicked()
    {
        clockInButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(true);
        Debug.Log("切換到確認按鈕");
    }

    public void OnConfirmButtonClicked()
    {
        // 防重複點擊保護
        if (!confirmButton.gameObject.activeSelf) return;

        confirmButton.gameObject.SetActive(false);
        successImage.gameObject.SetActive(true);

        // 觸發 Part B 行為
        TriggerPostCheckInBehavior();

        // 啟動關閉流程
        StartCoroutine(CompleteCheckInProcess());
    }

    private void TriggerPostCheckInBehavior()
    {
        // 停止閃爍並禁用互動
        computerAnimator.SetBool(blinkParam, false);
        interactionCollider.enabled = false;

        // 觸發海獺 Part B 行為
        FindObjectOfType<OtterDialogue>()?.SwitchToPartB();
        FindObjectOfType<OtterBaseMovement>()?.StartPartBBehavior();
    }

    IEnumerator CompleteCheckInProcess()
    {
        yield return new WaitForSecondsRealtime(4f);
        successImage.gameObject.SetActive(false);
        CloseComputerInterface();
    }

    void OpenComputerInterface()
    {
        Time.timeScale = 0;
        computerUI.SetActive(true);
        computerUI.transform.SetAsLastSibling(); // UI置頂
        clockInButton.gameObject.SetActive(true);
        FindObjectOfType<OtterDialogue>()?.StopDialogues();
        Debug.Log("打卡介面已開啟");
    }

    public void CloseComputerInterface()
    {
        Time.timeScale = 1;
        computerUI.SetActive(false);
        ResetUI();
        Debug.Log("打卡介面已完全關閉");
    }

    // 安全關閉方法
    public void ForceCloseInterface()
    {
        StopAllCoroutines();
        CloseComputerInterface();
        Debug.Log("強制關閉所有介面");
    }
}