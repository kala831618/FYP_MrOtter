// ComputerInteraction.cs
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject checkInPanel;

    void OnMouseDown()
    {
        if (GetComponent<Animator>().GetBool("Blink"))
        {
            checkInPanel.SetActive(true);
            Time.timeScale = 0; // 暫停遊戲
        }
    }

    public void ConfirmCheckIn()
    {
        checkInPanel.SetActive(false);
        Time.timeScale = 1;
        GetComponent<Animator>().SetBool("Blink", false);
        // 顯示成功提示（自行添加 UI Text）
    }
}