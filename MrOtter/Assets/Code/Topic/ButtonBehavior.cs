using UnityEngine; // �K�[�o��

public class ButtonBehavior : MonoBehaviour // �T�{�~�Ӧ� MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite selectedSprite;
    private bool isSelected;

    void OnMouseDown() => ToggleState();

    public void ToggleState()
    {
        isSelected = !isSelected;
        GetComponent<SpriteRenderer>().sprite =
            isSelected ? selectedSprite : normalSprite;
    }
}