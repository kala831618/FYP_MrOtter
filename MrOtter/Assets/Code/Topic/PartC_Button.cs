// PartC_Button.cs
using UnityEngine;

public class PartC_Button : MonoBehaviour
{
    void OnMouseDown()
    {
        TopicManager.Instance.SwitchToPartD();
    }
}