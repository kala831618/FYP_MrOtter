using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [Header("移動參數")]
    public float moveSpeed = 5f;  // 移動速度

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 獲取輸入值 (-1 到 1)
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D 或 ←→
        movement.y = Input.GetAxisRaw("Vertical");   // W/S 或 ↑↓
    }

    void FixedUpdate()
    {
        // 標準化向量避免斜向移動加速
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // 應用移動 (兩種方式擇一使用)

        // 方式 1：直接修改位置 (無物理碰撞)
        // transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);

        // 方式 2：物理移動 (需 Rigidbody2D，可配合碰撞體)
        rb.velocity = movement * moveSpeed;
    }
}