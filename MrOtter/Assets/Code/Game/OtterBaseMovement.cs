// OtterMovement.cs
using UnityEngine;

public class OtterBaseMovement : MonoBehaviour
{
    private Animator anim;
    private Vector2 input;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        // 更新動畫參數
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetBool("IsMoving", input.magnitude > 0.1f);
    }
}