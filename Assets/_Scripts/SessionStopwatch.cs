using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class SessionStopwatch : MonoBehaviour
{
    public TMP_Text timerText;
    private float TimerCounting = 0f;
    private bool isTimerOn = false;

    void Update()
    {
        if (isTimerOn)
        {
            TimerCounting += Time.deltaTime;
            //UpdateTimerText();
        }

    }
    private void Start()
    {
        isTimerOn = false;
        timerText.text = "Duration: ";

    }

    public void StartTimer()
    {
        isTimerOn = true;
        TimerCounting = 0f;
    }
    public void EndTimer()
    {
        isTimerOn = false;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(TimerCounting / 60);
        int seconds = Mathf.FloorToInt(TimerCounting % 60);


        timerText.text = "Duration: ";
        timerText.text += string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }

}
