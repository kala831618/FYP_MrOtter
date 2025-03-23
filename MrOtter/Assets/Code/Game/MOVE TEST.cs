// OtterMovement.cs
using UnityEngine;

public class OtterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;      // 移動速度
    public float minWaitTime = 1f;    // 停留最短時間
    public float maxWaitTime = 3f;    // 停留最長時間
    public Vector2 moveAreaMin;      // 移動範圍最小值
    public Vector2 moveAreaMax;      // 移動範圍最大值

    private Vector2 targetPosition;
    private Animator animator;
    private bool isMoving;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetNewDestination();
    }

    void Update()
    {
        // 計算移動方向
        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        
        // 更新位置
        if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            UpdateAnimation(moveDirection);
            isMoving = true;
        }
        else
        {
            if (isMoving)
            {
                // 到達目標後等待隨機時間
                isMoving = false;
                Invoke("SetNewDestination", Random.Range(minWaitTime, maxWaitTime));
            }
            animator.SetBool("IsMoving", false);
        }

        animator.SetBool("IsMoving", isMoving);
    }

    void SetNewDestination()
    {
        // 在指定範圍內隨機生成新目標點
        targetPosition = new Vector2(
            Random.Range(moveAreaMin.x, moveAreaMax.x),
            Random.Range(moveAreaMin.y, moveAreaMax.y)
        );
        isMoving = true;
    }

    void UpdateAnimation(Vector2 direction)
    {
        // 根據方向設置動畫參數
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            animator.SetFloat("DirectionX", direction.x);
            animator.SetFloat("DirectionY", 0);
        }
        else
        {
            animator.SetFloat("DirectionY", direction.y);
            animator.SetFloat("DirectionX", 0);
        }
    }
}