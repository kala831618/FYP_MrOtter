using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 2f; // �������ʳt��
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        // ��� Rigidbody2D �ե�
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody2D found on " + gameObject.name);
            return; // �p�G�S�� Rigidbody2D�A�h�����沾���޿�
        }

        // �H���ͦ���l��V
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // �]�m��l�Y��
        transform.localScale = new Vector3(0.18f, 0.18f, 1f);
    }

    void Update()
    {
        if (rb != null)
        {
            CheckBoundary();
            // ���ʳ�
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
            // ��s�����¦V
            UpdateFishOrientation();
        }
    }

    void CheckBoundary()
    {
        // ���������e��m
        Vector2 position = transform.position;

        // �ˬd X ���
        if (position.x <= -8 || position.x >= 8)
        {
            // ���� X ��V
            direction.x = -direction.x;

            // �T�O���b��ɤ�
            position.x = Mathf.Clamp(position.x, -8 + 0.1f, 8 - 0.1f);
            transform.position = position; // ��s������m
        }

        // �ˬd Y ���
        if (position.y <= -3 || position.y >= 3)
        {
            // ���� Y ��V
            direction.y = -direction.y;

            // �T�O���b��ɤ�
            position.y = Mathf.Clamp(position.y, -3 + 0.1f, 3 - 0.1f);
            transform.position = position; // ��s������m
        }
    }

    void UpdateFishOrientation()
    {
        // �ھڤ�V½�೽���¦V
        if (direction.x < 0)
        {
            // �V����ʡA½�೽
            transform.localScale = new Vector3(-0.18f, 0.18f, 1f);
        }
        else if (direction.x > 0)
        {
            // �V�k��ʡA���V
            transform.localScale = new Vector3(0.18f, 0.18f, 1f);
        }
    }
}