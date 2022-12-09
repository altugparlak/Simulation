using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimeText = null;

    private void OnEnable()
    {
        EventHandler.AdvanceGameMinuteEvent += UpdateGameTime;
    }

    private void OnDisable()
    {
        EventHandler.AdvanceGameMinuteEvent -= UpdateGameTime;
    }

    private void UpdateGameTime(int gameHour, int gameMinute, int gameSecond)
    {
        // Update time

        //gameMinute = gameMinute - (gameMinute % 10);
        string minute;
        string hour;

        if (gameHour < 10)
            hour = "0" + gameHour.ToString();
        else
            hour = gameHour.ToString();

        if (gameMinute < 10)
            minute = "0" + gameMinute.ToString();
        else
            minute = gameMinute.ToString();

        gameTimeText.SetText(hour + " : " + minute);
    }
}
