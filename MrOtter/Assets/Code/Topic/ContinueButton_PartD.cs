using UnityEngine;

public class ContinueButton_PartD : MonoBehaviour
{
    void OnMouseDown()
    {
        // �w���ˬd�޲z���O�_�s�b
        PartD_Manager manager = FindObjectOfType<PartD_Manager>();
        if (manager != null)
        {
            manager.OnContinueClicked();
        }
        else
        {
            Debug.LogError("�䤣�� PartD_Manager!");
        }

    }
}