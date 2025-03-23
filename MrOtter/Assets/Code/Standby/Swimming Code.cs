using UnityEngine;
using System.Collections;

public class OtterMovement : MonoBehaviour
{
    public float speed = 2f;
    public float boostSpeed = 5f; // 加速速度
    public float boostDuration = 1f; // 加速持續時間
    private Vector2 direction;
    public AudioClip soundEffect;

    private AudioSource audioSource;
    private bool isBoosting = false; // 追蹤是否正在加速
    private Animator animator; // 動畫控制器

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>(); // 獲取 Animator 組件
        animator.SetBool("IsIdle", true); // 初始設置為 Idle 狀態
        ChangeDirection(); // 開始隨機移動
    }

    void Update()
    {
        // 移動海獺
        transform.Translate(direction * speed * Time.deltaTime);

        // 限制海獺在畫面內游泳
        Vector2 position = transform.position;

        // 檢查 X 軸邊界
        if (position.x < -8 || position.x > 8)
        {
            direction.x = -direction.x; // 反向游泳
        }

        // 檢查 Y 軸邊界
        if (position.y < -3f || position.y > 3f)
        {
            direction.y = -direction.y; // 反向游泳
        }

        // 更新動畫狀態
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

        // 隨機生成方向
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // 根據隨機方向設置動畫
        if (direction.x < 0)
        {
            animator.SetBool("IsMovingLeft", true); // 播放左側動畫
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMovingRight", false);
        }
        else if (direction.x > 0)
        {
            animator.SetBool("IsMovingRight", true); // 播放右側動畫
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMovingLeft", false);
        }

        if (!isBoosting) // 只有在未加速時才觸發
        {
            StartCoroutine(BoostSpeed());
        }
    }

    private IEnumerator BoostSpeed()
    {
        isBoosting = true; // 設置為加速狀態
        float originalSpeed = speed; // 保存原始速度
        speed = boostSpeed; // 設置加速速度
        yield return new WaitForSeconds(boostDuration); // 等待加速持續時間

        // 加速結束後恢復到 Idle 狀態
        speed = originalSpeed; // 恢復原始速度
        animator.SetBool("IsIdle", true); // 返回到 Idle 狀態
        animator.SetBool("IsMovingLeft", false);
        animator.SetBool("IsMovingRight", false);

        isBoosting = false; // 恢復為未加速狀態
    }

    private void ChangeDirection()
    {
        // 隨機生成方向
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}