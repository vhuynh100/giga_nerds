using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText;
    private float TimerCounting = 500f;

    void Update()
    {
        if (TimerCounting > 0)
        {
            TimerCounting -= Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void SetTimer(float minutes)
    {
        TimerCounting = minutes * 60; // Convert minutes to seconds
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(TimerCounting / 60);
        int seconds = Mathf.FloorToInt(TimerCounting % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Methods linked to buttons
    public void SetFiveMinutes()
    {
        Debug.Log("button got clickd");
        SetTimer(5f);
    }
    public void SetTenMinutes() => SetTimer(10f);
    public void SetFifteenMinutes() => SetTimer(15f);
}
