using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    // 移動參數
    public float speed = 2f;
    [Tooltip("建議2-3倍即可")]
    public float boostMultiplier = 0.4f;
    public float boostDuration = 0.2f;
    public float accelerationSharpness = 1.5f;

    // 物理控制
    [Range(0, 1)] public float drag = 2f;

    // 音效參數
    public AudioClip clickSound;
    [Range(0, 1)] public float volume = 1f;

    private Vector2 direction;
    private Rigidbody2D rb;
    private Coroutine speedBoostCoroutine;
    private float originalSpeed;
    private AudioSource audioSource;
    private Vector2 targetVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        originalSpeed = speed;
        InitializeDirection();  // 初始化方向
        ApplyInitialScale();    // 初始化縮放

        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.drag = drag;
        }
    }

    void Update()
    {
        if (rb != null)
        {
            CheckBoundary();
            UpdateMovement();
            UpdateFishOrientation();  // 新增方法調用
        }
    }

    // 新增方法：初始化方向
    void InitializeDirection()
    {
        do
        {
            direction = new Vector2(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized;
        } while (direction.magnitude < 0.1f);
    }

    // 新增方法：更新魚的朝向
    void UpdateFishOrientation()
    {
        transform.localScale = new Vector3(
            Mathf.Sign(direction.x) * 0.18f,
            0.18f,
            1f
        );
    }

    void ApplyInitialScale()
    {
        UpdateFishOrientation();
    }

    void UpdateMovement()
    {
        targetVelocity = direction * speed;
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * accelerationSharpness);
    }

    void CheckBoundary()
    {
        Vector2 position = transform.position;

        if (position.x <= -8 || position.x >= 8)
        {
            direction.x = -direction.x;
            position.x = Mathf.Clamp(position.x, -8 + 0.1f, 8 - 0.1f);
            transform.position = position;
        }

        if (position.y <= -3 || position.y >= 3)
        {
            direction.y = -direction.y;
            position.y = Mathf.Clamp(position.y, -3 + 0.1f, 3 - 0.1f);
            transform.position = position;
        }
    }

    private void OnMouseDown()
    {
        PlayClickSound();
        ChangeDirection();
        ApplySpeedBoost();
    }

    void ChangeDirection()
    {
        InitializeDirection();  // 重新初始化方向
        UpdateFishOrientation(); // 更新視覺方向

        float forceMultiplier = Random.Range(5f, 15f);
        rb.AddForce(direction * forceMultiplier, ForceMode2D.Impulse);
    }

    void ApplySpeedBoost()
    {
        if (speedBoostCoroutine != null) StopCoroutine(speedBoostCoroutine);
        speedBoostCoroutine = StartCoroutine(SpeedBoost());
    }

    private IEnumerator SpeedBoost()
    {
        float currentBoost = boostMultiplier;

        float elapsed = 0f;
        while (elapsed < 0.2f)
        {
            currentBoost = Mathf.Lerp(1f, boostMultiplier, elapsed / 0.2f);
            speed = originalSpeed * currentBoost;
            elapsed += Time.deltaTime;
            yield return null;
        }

        speed = originalSpeed * boostMultiplier;
        yield return new WaitForSeconds(boostDuration * 0.4f);

        elapsed = 0f;
        while (elapsed < 0.2f)
        {
            currentBoost = Mathf.Lerp(boostMultiplier, 1f, elapsed / 0.2f);
            speed = originalSpeed * currentBoost;
            elapsed += Time.deltaTime;
            yield return null;
        }

        speed = originalSpeed;
    }

    private void PlayClickSound()
    {
        if (clickSound == null) return;

        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(clickSound, volume);
        }
        else
        {
            AudioSource.PlayClipAtPoint(clickSound, transform.position, volume);
        }
    }
}