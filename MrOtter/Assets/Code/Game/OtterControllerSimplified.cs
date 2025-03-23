using System.Collections;  // 新增這行
using UnityEngine;         // 原有引用保留

public class OtterControllerSimplified : MonoBehaviour
{
    public void StartRandomMove()
    {
        GetComponent<OtterMovement>().enabled = false; // 禁用原有移动
        StartCoroutine(RandomMove());
    }

    private IEnumerator RandomMove()  // 注意這裡的返回類型
    {
        while (true)
        {
            float targetX = Random.Range(-5f, 5f);
            while (Mathf.Abs(transform.position.x - targetX) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    new Vector2(targetX, transform.position.y),
                    2f * Time.deltaTime
                );
                yield return null;
            }
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}