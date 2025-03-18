using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [Header("���ʰѼ�")]
    public float moveSpeed = 5f;  // ���ʳt��

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �����J�� (-1 �� 1)
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D �� ����
        movement.y = Input.GetAxisRaw("Vertical");   // W/S �� ����
    }

    void FixedUpdate()
    {
        // �зǤƦV�q�קK�צV���ʥ[�t
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // ���β��� (��ؤ覡�ܤ@�ϥ�)

        // �覡 1�G�����ק��m (�L���z�I��)
        // transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);

        // �覡 2�G���z���� (�� Rigidbody2D�A�i�t�X�I����)
        rb.velocity = movement * moveSpeed;
    }
}