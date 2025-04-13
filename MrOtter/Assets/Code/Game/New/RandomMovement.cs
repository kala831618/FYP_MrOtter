using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionTime = 3f;
    public float stopProbability = 0.3f;
    public LayerMask obstacleLayer;

    private Vector2[] directions = {
        Vector2.right,
        Vector2.left,
        Vector2.zero
    };

    private Animator animator;
    private Vector2 currentDirection;
    private bool isMoving;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            if (Random.value < stopProbability)
            {
                currentDirection = Vector2.zero;
                isMoving = false;
            }
            else
            {
                currentDirection = GetValidDirection();
                isMoving = true;
            }

            UpdateAnimation();
            yield return new WaitForSeconds(changeDirectionTime);
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = currentDirection * moveSpeed;

            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                currentDirection,
                0.7f,
                obstacleLayer
            );

            Debug.DrawRay(transform.position, currentDirection * 0.7f, Color.red);

            if (hit.collider != null)
            {
                StartCoroutine(ChangeDirectionImmediately());
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator ChangeDirectionImmediately()
    {
        isMoving = false;
        UpdateAnimation();
        yield return new WaitForSeconds(0.1f);

        currentDirection = GetValidDirection();
        isMoving = true;
        UpdateAnimation();
        yield return new WaitForSeconds(1f);
    }

    Vector2 GetValidDirection()
    {
        Vector2 avoidDirection = -currentDirection;
        Vector2 newDir;

        do
        {
            newDir = directions[Random.Range(0, directions.Length)];
        } while (newDir == avoidDirection || newDir == currentDirection);

        return newDir;
    }

    void UpdateAnimation()
    {
        animator.SetFloat("Horizontal", currentDirection.x);
        animator.SetBool("IsMoving", isMoving);
    }
}