// OtterDirectionController.cs
using UnityEngine;

public class OtterDirectionController : MonoBehaviour
{
    private Animator anim;
    private Vector2 lastDirection;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // �����J��V�]�i�������A�������޿�^
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        // �u���ųB�z�G������V�u��
        if (direction != Vector2.zero)
        {
            if (Mathf.Abs(direction.y) > 0.1f)
            {
                direction.x = 0; // ����������J
            }
            lastDirection = direction;
        }

        // �ǻ��Ѽƨ� Animator
        anim.SetFloat("MoveX", lastDirection.x);
        anim.SetFloat("MoveY", lastDirection.y);
    }
}