using System.Collections; // ← 必須添加的命名空間
using UnityEngine;

public class OtterBaseMovement : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 2f;
    private Animator anim;
    private bool isAtPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(MoveToPosition()); // 需要 System.Collections 來使用協程
    }

    IEnumerator MoveToPosition()
    {
        anim.SetBool("IsMoving", true);

        while (Vector2.Distance(transform.position, targetPosition.position) > 0.1f)
        {
            Vector2 direction = (targetPosition.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);

            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveY", direction.y);
            yield return null;
        }

        anim.SetBool("IsMoving", false);
        isAtPosition = true;
    }
}