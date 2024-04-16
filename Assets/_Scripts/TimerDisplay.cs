using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject Options;
    private float TimerCounting = 0f;
    private bool isTimerOn = false;
    private bool toggleOptions = false;

    void Update()
    {
        if (TimerCounting > 0 && isTimerOn)
        {
            TimerCounting -= Time.deltaTime;
            UpdateTimerText();
        }
        else if (TimerCounting <= 0 && isTimerOn)
        { 
            isTimerOn = false;
            timerText.text = "Times Up!"; 
        }
    }
    private void Start()
    {
        timerText.text = "Set Timer";
    }

    public void SetTimer(float minutes)
    {
        isTimerOn = true;
        TimerCounting = minutes * 60; // Convert minutes to seconds
        UpdateTimerText();
    }
    public void showOptions()
    {
        toggleOptions = !toggleOptions;
        Options.SetActive(toggleOptions);
    }


    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(TimerCounting / 60);
        int seconds = Mathf.FloorToInt(TimerCounting % 60);
        if(seconds >= 0 && minutes >= 0)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }

}
