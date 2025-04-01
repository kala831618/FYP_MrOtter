using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("发球设置")]
    public float serveForce = 500f;     // 发球力度
    public bool isServed = false;       // 发球状态

    [Header("反弹设置")]
    public float baseSpeed = 8f;        // 基础移动速度
    public float speedIncrease = 1.1f;  // 每次反弹加速

    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    private Vector3 initialPosition; // 新增初始位置记录

    void Start()
    {
        initialPosition = transform.position; // 记录初始位置
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // 初始无重力
    }

    void Update()
    {
        lastVelocity = rb.velocity;

        // 发球后启用物理反弹
        if (isServed && rb.gravityScale == 0)
        {
            rb.gravityScale = 1;
        }
    }

    void OnMouseDown()
    {
        if (!isServed)
        {
            Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), 1).normalized;
            rb.AddForce(randomDir * serveForce);
            GameObject.Find("PlayerTexts").SetActive(false);
            isServed = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // 玩家反弹逻辑
            float hitPos = col.transform.InverseTransformPoint(transform.position).x;
            Vector2 dir = new Vector2(Mathf.Sign(hitPos), 1).normalized;
            rb.velocity = dir * baseSpeed * speedIncrease;
            baseSpeed *= speedIncrease;
        }
        else if (col.gameObject.CompareTag("Ground"))
        {
            // 触地重置由GameManager处理
        }
        else
        {
            // 墙体和天花板反弹
            Vector2 reflectDir = Vector2.Reflect(lastVelocity.normalized, col.contacts[0].normal);
            rb.velocity = reflectDir * lastVelocity.magnitude;
        }
    }

    public void ResetBall()
    {
        transform.position = initialPosition; // 使用记录的初始位置
        rb.velocity = Vector2.zero;
        isServed = false;
        rb.gravityScale = 0;
    }
}