using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterMove : MonoBehaviour
{
    [Header("移動參數")]
    public float 速度 = 5f; // 公開變量建議用英文命名，如：public float speed;

    // 組件引用
    private Rigidbody2D 剛體;
    private Animator 人物動畫;

    // 輸入值緩存
    private float 橫座標X;
    private float 縱座標Y;
    private Vector2 按鍵輸入;

    void Start()
    {
        // 正確獲取組件（注意組件必須存在於物體上）
        剛體 = GetComponent<Rigidbody2D>();
        人物動畫 = GetComponent<Animator>();

        // 安全檢查
        if (剛體 == null) Debug.LogError("缺少 Rigidbody2D 組件");
        if (人物動畫 == null) Debug.LogError("缺少 Animator 組件");
    }

    void Update()
    {
        切換動畫(); // 動畫控制在 Update
    }

    void FixedUpdate()
    {
        // 移動控制在 FixedUpdate
        橫座標X = Input.GetAxisRaw("Horizontal");
        縱座標Y = Input.GetAxisRaw("Vertical");

        按鍵輸入 = new Vector2(橫座標X, 縱座標Y).normalized; // 標準化防止斜向加速

        剛體.velocity = 按鍵輸入 * 速度;
    }

    private void 切換動畫()
    {
        // 使用明確的動畫參數名稱（需與 Animator 完全匹配）
        bool 是否移動中 = 按鍵輸入 != Vector2.zero;
        人物動畫.SetBool("IsMoving", 是否移動中);

        if (是否移動中)
        {
            人物動畫.SetFloat("X", 橫座標X);
            人物動畫.SetFloat("Y", 縱座標Y);
        }
    }
}

