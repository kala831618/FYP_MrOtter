using UnityEngine;
using System.Collections;

public class OtterMovement : MonoBehaviour
{
    public float speed = 2f;
    public float boostSpeed = 5f; // �[�t�t��
    public float boostDuration = 1f; // �[�t����ɶ�
    private Vector2 direction;
    public AudioClip soundEffect;

    private AudioSource audioSource;
    private bool isBoosting = false; // �l�ܬO�_���b�[�t
    private Animator animator; // �ʵe���

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>(); // ��� Animator �ե�
        animator.SetBool("IsIdle", true); // ��l�]�m�� Idle ���A
        ChangeDirection(); // �}�l�H������
    }

    void Update()
    {
        // ���ʮ�á
        transform.Translate(direction * speed * Time.deltaTime);

        // �����á�b�e������a
        Vector2 position = transform.position;

        // �ˬd X �b���
        if (position.x < -8 || position.x > 8)
        {
            direction.x = -direction.x; // �ϦV��a
        }

        // �ˬd Y �b���
        if (position.y < -3f || position.y > 3f)
        {
            direction.y = -direction.y; // �ϦV��a
        }

        // ��s�ʵe���A
        if (direction.x == 0)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
        }
    }

    private void OnMouseDown()
    {
        if (soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }

        // �H���ͦ���V
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // �ھ��H����V�]�m�ʵe
        if (direction.x < 0)
        {
            animator.SetBool("IsMovingLeft", true); // ���񥪰��ʵe
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMovingRight", false);
        }
        else if (direction.x > 0)
        {
            animator.SetBool("IsMovingRight", true); // ����k���ʵe
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMovingLeft", false);
        }

        if (!isBoosting) // �u���b���[�t�ɤ~Ĳ�o
        {
            StartCoroutine(BoostSpeed());
        }
    }

    private IEnumerator BoostSpeed()
    {
        isBoosting = true; // �]�m���[�t���A
        float originalSpeed = speed; // �O�s��l�t��
        speed = boostSpeed; // �]�m�[�t�t��
        yield return new WaitForSeconds(boostDuration); // ���ݥ[�t����ɶ�

        // �[�t�������_�� Idle ���A
        speed = originalSpeed; // ��_��l�t��
        animator.SetBool("IsIdle", true); // ��^�� Idle ���A
        animator.SetBool("IsMovingLeft", false);
        animator.SetBool("IsMovingRight", false);

        isBoosting = false; // ��_�����[�t���A
    }

    private void ChangeDirection()
    {
        // �H���ͦ���V
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}