using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalClock : MonoBehaviour
{
    public Text timeText;  // �j�wUI Text����
    public bool includeDate = true; // �O�_��ܤ��
    public string timeFormat = "HH:mm:ss"; // �ɶ��榡
    public string dateFormat = "yyyy-MM-dd dddd"; // ����榡

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