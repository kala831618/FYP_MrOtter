using UnityEngine; // 添加這行

public class ButtonBehavior : MonoBehaviour // 確認繼承自 MonoBehaviour
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