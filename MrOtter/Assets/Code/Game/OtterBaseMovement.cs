using System.Collections;
using UnityEngine;

public class OtterBaseMovement : MonoBehaviour
{
    [Header("Part A 設定")]
    public Transform targetPosition;
    public float partAMoveSpeed = 2f;

    [Header("Part B 設定")]
    [SerializeField] private Vector2 partBMoveAreaCenter;
    [SerializeField] private Vector2 partBMoveSize = new Vector2(8, 5);
    [SerializeField] private float partBMinWait = 1f;
    [SerializeField] private float partBMaxWait = 4f;
    [SerializeField] private float partBMoveSpeed = 1.5f; // 獨立速度參數

    [Header("碰撞設定")]
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float collisionReactDistance = 0.8f;

    private Animator anim;
    private bool isAtPosition;
    private bool isPartB = false;
    private Coroutine movementCoroutine;
    private Vector2 currentDirection;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(PartA_Behavior());
    }

    IEnumerator PartA_Behavior()
    {
        anim.SetBool("IsMoving", true);

        while (Vector2.Distance(transform.position, targetPosition.position) > 0.1f)
        {
            Vector2 direction = (targetPosition.position - transform.position).normalized;
            UpdateMovement(direction, partAMoveSpeed);
            yield return null;
        }

        anim.SetBool("IsMoving", false);
        isAtPosition = true;
    }

    public void StartPartBBehavior()
    {
        isPartB = true;
        if (movementCoroutine != null) StopCoroutine(movementCoroutine);
        movementCoroutine = StartCoroutine(PartB_RandomMovement());
    }

    IEnumerator PartB_RandomMovement()
    {
        while (isPartB)
        {
            Vector2 target = GenerateRandomTarget();

            anim.SetBool("IsMoving", true);
            while (Vector2.Distance(transform.position, target) > 0.1f)
            {
                Vector2 dir = (target - (Vector2)transform.position).normalized;
                UpdateMovement(dir, partBMoveSpeed);
                yield return null;
            }

            anim.SetBool("IsMoving", false);
            yield return new WaitForSeconds(Random.Range(partBMinWait, partBMaxWait));
        }
    }

    private void UpdateMovement(Vector2 direction, float speed)
    {
        currentDirection = direction;
        transform.position = Vector2.MoveTowards(
            transform.position,
            transform.position + (Vector3)direction,
            speed * Time.deltaTime
        );

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
    }

    private Vector2 GenerateRandomTarget()
    {
        return new Vector2(
            partBMoveAreaCenter.x + Random.Range(-partBMoveSize.x / 2, partBMoveSize.x / 2),
            partBMoveAreaCenter.y + Random.Range(-partBMoveSize.y / 2, partBMoveSize.y / 2)
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPartB && ((1 << collision.gameObject.layer) & obstacleLayer) != 0)
        {
            HandleCollisionReaction();
        }
    }

    private void HandleCollisionReaction()
    {
        if (movementCoroutine != null) StopCoroutine(movementCoroutine);

        // 反彈後退
        transform.position += (Vector3)(-currentDirection) * collisionReactDistance;

        // 立即生成新目標
        movementCoroutine = StartCoroutine(PartB_RandomMovement());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(partBMoveAreaCenter, partBMoveSize);

        Gizmos.color = Color.yellow;
        if (targetPosition != null)
            Gizmos.DrawSphere(targetPosition.position, 0.3f);

        // 繪製當前方向指示器
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, currentDirection * 1f);
    }
}