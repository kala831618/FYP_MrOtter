using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;      // UI Text元件
    public string[] dialogues;     // 預設至少10句對話
    public float showInterval = 5f; // 對話顯示間隔
    public float displayTime = 3f; // 對話持續時間

    void Start()
    {
        dialogues = new string[]
        {
            "今天天氣真好！",
            "紅磡要怎麼去？",
            "肚子好餓...咕嚕咕嚕",
            "我可以扮工嗎?",
            "PolyU有賣新品!",
            "發現地上有錢！",
            "小心水母會咬人！",
            "海獺和水獺是不一樣的！",
            "工作累了~偷懶一下~",
            "我也想買Polyu周邊啊~"
        };

        StartCoroutine(ShowRandomDialogue());
    }

    IEnumerator ShowRandomDialogue()
    {
        while (true)
        {
            yield return new WaitForSeconds(showInterval);
            string randomDialogue = dialogues[Random.Range(0, dialogues.Length)];
            dialogueText.text = randomDialogue;
            yield return new WaitForSeconds(displayTime);
            dialogueText.text = "";
        }
    }
}