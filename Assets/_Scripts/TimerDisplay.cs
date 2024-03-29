using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private float countdownDuration = 300; // Default duration (e.g., 300 for 5 minutes)
    private bool isTimerRunning = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            float timeRemaining = countdownDuration - (Time.time - startTime);
            if (timeRemaining <= 0)
            {
                isTimerRunning = false;
                timeRemaining = 0;
            }
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            int milliseconds = Mathf.FloorToInt((timeRemaining * 1000) % 1000);
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void SetDuration(float durationInSeconds)
    {
        countdownDuration = durationInSeconds;
    }
}




