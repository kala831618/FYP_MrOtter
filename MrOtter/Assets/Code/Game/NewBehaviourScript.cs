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
            Time.timeScale = 0; // �Ȱ��C��
        }
    }

    public void ConfirmCheckIn()
    {
        checkInPanel.SetActive(false);
        Time.timeScale = 1;
        GetComponent<Animator>().SetBool("Blink", false);
        // ��ܦ��\���ܡ]�ۦ�K�[ UI Text�^
    }
}