using System.Collections; // �� �����K�[���R�W�Ŷ�
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
        StartCoroutine(MoveToPosition()); // �ݭn System.Collections �ӨϥΨ�{
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