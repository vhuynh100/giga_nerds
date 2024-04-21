using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject Options;
    public Image FlagImage;
    public Sprite englishFlag;
    public Sprite spanishFlag;
    public GameObject Flag;
    public GameObject promptNextLang;
    private float TimerCounting = 0f;
    private bool isTimerOn = false;
    private bool onSecondLanguage = false;
    private bool toggleOptions = false;
    private float lastTime = 0f;

    [SerializeField] private TimerStart timerStart;
    private int playerNum = 0;

    void Update()
    {
        if(timerStart.GetPlayer1Ready() == true && timerStart.GetPlayer2Ready() == true && !isTimerOn)
        {
            SetTimer(timerStart.GetTimerDuration());
        }

        if (TimerCounting > 0 && isTimerOn)
        {
            TimerCounting -= Time.deltaTime;
            UpdateTimerText();
        }
        else if (TimerCounting <= 0 && isTimerOn)
        { 
            isTimerOn = false;
            timerText.text = "Times Up!"; 
            if (!onSecondLanguage)
            {
                //enable popup button
                promptNextLang.SetActive(true);
                Options.SetActive(false);
            }

            else if (onSecondLanguage)
            {
                Start();
            }
        }
    }
    private void Start()
    {
        Options.SetActive(false);
        isTimerOn = false;
        timerText.text = "Set Timer";
        Flag.SetActive(false);
        FlagImage.sprite = englishFlag;
        promptNextLang.SetActive(false);
        onSecondLanguage = false;
    }

    public void SetLastTimer()
    {
        FlagImage.sprite = spanishFlag;
        promptNextLang.SetActive(false);
        onSecondLanguage = true;
        SetTimer(lastTime);
    }

    public void SetTimer(float minutes)
    {
        lastTime = minutes;
        print("======= set timer to " +  minutes);
        //isTimerOn = true;
        Flag.SetActive(true);  
        TimerCounting = minutes * 60; // Convert minutes to seconds
        if (onSecondLanguage)
        {
            FlagImage.sprite = spanishFlag;
        }
        UpdateTimerText();
    }

    public void SetTimerDuration(float minutes)
    {
        lastTime = minutes;
        isTimerOn = true;
        Flag.SetActive(true);
        TimerCounting = minutes * 60; // Convert minutes to seconds
        if (onSecondLanguage)
        {
            FlagImage.sprite = spanishFlag;
        }
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

    private void SetPlayerReady()
    {
        if(timerStart.GetPlayer1Ready() == false)
        {
            timerStart.SetPlayer1Ready(true);
            playerNum = 1;
        }
        else
        {
            timerStart.SetPlayer2Ready(true);
            playerNum = 2;
        }
    }

    private void SetTimerDuration()
    {

    }

}
