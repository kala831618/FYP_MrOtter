using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("游戏元素")]
    public BallController ball;
    public Transform floor;
    public GameObject playerTexts; // 拖拽赋值

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (ball.transform.position.y < floor.position.y - 1f)
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        ball.ResetBall();
        playerTexts.SetActive(true); // 改用拖拽引用
    }
}