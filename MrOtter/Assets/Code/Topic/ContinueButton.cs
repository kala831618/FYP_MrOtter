using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    void OnMouseDown()
    {
        FindObjectOfType<PartB_Manager>().OnContinueClicked();
    }
}