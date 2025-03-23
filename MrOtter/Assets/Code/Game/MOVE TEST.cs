// OtterMovement.cs
using UnityEngine;

public class OtterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;      // ���ʳt��
    public float minWaitTime = 1f;    // ���d�̵u�ɶ�
    public float maxWaitTime = 3f;    // ���d�̪��ɶ�
    public Vector2 moveAreaMin;      // ���ʽd��̤p��
    public Vector2 moveAreaMax;      // ���ʽd��̤j��

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
        // �p�Ⲿ�ʤ�V
        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        
        // ��s��m
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
                // ��F�ؼЫᵥ���H���ɶ�
                isMoving = false;
                Invoke("SetNewDestination", Random.Range(minWaitTime, maxWaitTime));
            }
            animator.SetBool("IsMoving", false);
        }

        animator.SetBool("IsMoving", isMoving);
    }

    void SetNewDestination()
    {
        // �b���w�d���H���ͦ��s�ؼ��I
        targetPosition = new Vector2(
            Random.Range(moveAreaMin.x, moveAreaMax.x),
            Random.Range(moveAreaMin.y, moveAreaMax.y)
        );
        isMoving = true;
    }

    void UpdateAnimation(Vector2 direction)
    {
        // �ھڤ�V�]�m�ʵe�Ѽ�
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