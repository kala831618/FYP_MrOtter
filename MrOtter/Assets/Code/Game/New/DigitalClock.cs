using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalClock : MonoBehaviour
{
    public Text timeText;  // 綁定UI Text元件
    public bool includeDate = true; // 是否顯示日期
    public string timeFormat = "HH:mm:ss"; // 時間格式
    public string dateFormat = "yyyy-MM-dd dddd"; // 日期格式

    void Update()
    {
        DateTime now = DateTime.Now;
        string timeString = now.ToString(timeFormat);

        if (includeDate)
        {
            string dateString = now.ToString(dateFormat);
            timeText.text = $"{dateString}\n{timeString}";
        }
        else
        {
            timeText.text = timeString;
        }
    }
}