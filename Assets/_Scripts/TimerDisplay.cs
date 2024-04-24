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
    [SerializeField] private GameObject readyButton;

    private int playerNum = 0;
    private float timerDuration = 0;
    private float prevTimerDuration = 0;

    void Update()
    {
        print("==== playerNum: " + playerNum);
        if(timerStart.GetPlayer1Ready() == true && timerStart.GetPlayer2Ready() == true && !isTimerOn)
        {
            SetTimerDuration(timerStart.GetTimerDuration());
        }


        print("======= local timer duration: " + timerDuration);
        print("======= shared timer duration: " + timerStart.GetTimerDuration());



        if (timerStart.GetTimerDuration() != prevTimerDuration)
        {
            prevTimerDuration = timerStart.GetTimerDuration();
            SetTimer(timerStart.GetTimerDuration());
            if(playerNum == 1)
            {
                timerStart.SetPlayer1Ready(false);
                playerNum = 0;
                isTimerOn = false;

            } else if (playerNum == 2)
            {
                timerStart.SetPlayer2Ready(false);
                playerNum = 0;
                isTimerOn = false;
            }
        }

        if (timerStart.GetPlayer1Ready() == true && timerStart.GetPlayer2Ready() == true && TimerCounting > 0 && isTimerOn)
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
        timerDuration = minutes;
        timerStart.SetTimerDuration(minutes);
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
        timerStart.SetTimerDuration(minutes);
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

    public void SetPlayerReady()
    {
        if(playerNum == 0 && timerStart.GetPlayer1Ready() == false)
        {
            timerStart.SetPlayer1Ready(true);
            playerNum = 1;
        }
        else if (playerNum == 0 && timerStart.GetPlayer2Ready() == false)
        {
            timerStart.SetPlayer2Ready(true);
            playerNum = 2;
        }
    }

    public void SetPlayerUnReady()
    {
        if (playerNum == 1)
        {
            timerStart.SetPlayer1Ready(false);
        } else if ( playerNum == 2)
        {
            timerStart.SetPlayer2Ready(false);
        }
    }

    

}
