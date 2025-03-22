using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 2f; // 魚的移動速度
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        // 獲取 Rigidbody2D 組件
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody2D found on " + gameObject.name);
            return; // 如果沒有 Rigidbody2D，則不執行移動邏輯
        }

        // 隨機生成初始方向
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // 設置初始縮放
        transform.localScale = new Vector3(0.18f, 0.18f, 1f);
    }

    void Update()
    {
        if (rb != null)
        {
            CheckBoundary();
            // 移動魚
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
            // 更新魚的朝向
            UpdateFishOrientation();
        }
    }

    void CheckBoundary()
    {
        // 獲取魚的當前位置
        Vector2 position = transform.position;

        // 檢查 X 邊界
        if (position.x <= -8 || position.x >= 8)
        {
            // 反轉 X 方向
            direction.x = -direction.x;

            // 確保魚在邊界內
            position.x = Mathf.Clamp(position.x, -8 + 0.1f, 8 - 0.1f);
            transform.position = position; // 更新魚的位置
        }

        // 檢查 Y 邊界
        if (position.y <= -3 || position.y >= 3)
        {
            // 反轉 Y 方向
            direction.y = -direction.y;

            // 確保魚在邊界內
            position.y = Mathf.Clamp(position.y, -3 + 0.1f, 3 - 0.1f);
            transform.position = position; // 更新魚的位置
        }
    }

    void UpdateFishOrientation()
    {
        // 根據方向翻轉魚的朝向
        if (direction.x < 0)
        {
            // 向左游動，翻轉魚
            transform.localScale = new Vector3(-0.18f, 0.18f, 1f);
        }
        else if (direction.x > 0)
        {
            // 向右游動，正向
            transform.localScale = new Vector3(0.18f, 0.18f, 1f);
        }
    }
}