using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("点击区域设置")]
    public float clickRadius = 4f;         // 水平点击半径
    public float verticalSensitivity = 0.6f; // 垂直灵敏度（0-1）

    [Header("跳跃控制")]
    public float jumpForce = 12f;           // 跳跃初速度
    public float maxJumpHeight = 4.5f;       // 最大跳跃高度
    public float gravityMultiplier = 4.5f;   // 下落重力倍率

    [Header("移动设置")]
    public float moveStep = 1f;            // 横向移动步长

    private Rigidbody2D rb;
    private bool isGrounded;
    private float startY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f; // 初始化重力
    }

    void Update()
    {
        HandleInput();
        ApplyGravity();
        LimitJumpHeight();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 relativePos = clickPos - transform.position;

            if (IsInClickArea(relativePos))
            {
                if (IsJumpInput(relativePos))
                {
                    TryJump();
                }
                else
                {
                    MoveHorizontal(relativePos.x > 0);
                }
            }
        }
    }

    bool IsInClickArea(Vector2 relativePos)
    {
        // 修正括号匹配问题
        float a = clickRadius;
        float b = clickRadius * verticalSensitivity;

        // 正确闭合所有括号 ↓
        return (Mathf.Pow(relativePos.x / a, 2) + Mathf.Pow(relativePos.y / b, 2)) <= 1;
        //          正确闭合位置 → ↑
    }

    bool IsJumpInput(Vector2 relativePos)
    {
        // 垂直优先判断：Y轴差值占比超过60%
        return Mathf.Abs(relativePos.y) > Mathf.Abs(relativePos.x) * 0.6f;
    }

    void TryJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            startY = transform.position.y;
            isGrounded = false;
        }
    }

    void MoveHorizontal(bool moveRight)
    {
        float direction = moveRight ? moveStep : -moveStep;
        transform.Translate(direction, 0, 0);

        // 防止滑動
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void LimitJumpHeight()
    {
        if (transform.position.y >= startY + maxJumpHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    void ApplyGravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 简易接地检测
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            startY = transform.position.y;
        }
    }

    void OnDrawGizmos()
    {
        // 绘制点击范围椭圆
        Gizmos.color = new Color(0, 1, 1, 0.3f);
        DrawEllipseGizmo(transform.position, clickRadius, clickRadius * verticalSensitivity);

        // 绘制当前跳跃高度线
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            transform.position + Vector3.left,
            transform.position + Vector3.right
        );
    }

    void DrawEllipseGizmo(Vector3 center, float width, float height)
    {
        Vector3 lastPos = center + new Vector3(width, 0, 0);
        for (int i = 1; i <= 36; i++)
        {
            float angle = i * Mathf.PI * 2 / 36;
            Vector3 newPos = center + new Vector3(
                Mathf.Cos(angle) * width,
                Mathf.Sin(angle) * height,
                0
            );
            Gizmos.DrawLine(lastPos, newPos);
            lastPos = newPos;
        }
    }
}