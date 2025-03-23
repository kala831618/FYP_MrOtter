// OtterDirectionController.cs
using UnityEngine;

public class OtterDirectionController : MonoBehaviour
{
    private Animator anim;
    private Vector2 lastDirection;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 獲取輸入方向（可替換為你的移動邏輯）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        // 優先級處理：垂直方向優先
        if (direction != Vector2.zero)
        {
            if (Mathf.Abs(direction.y) > 0.1f)
            {
                direction.x = 0; // 取消水平輸入
            }
            lastDirection = direction;
        }

        // 傳遞參數到 Animator
        anim.SetFloat("MoveX", lastDirection.x);
        anim.SetFloat("MoveY", lastDirection.y);
    }
}