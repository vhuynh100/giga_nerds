using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Canvas
    [SerializeField] private GameObject translationMenu; 
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject timerMenu;

    // Circle UI Buttons
    //[SerializeField] private Button lingoLinkButton;
    //[SerializeField] private Button translationMenuButton;
    //[SerializeField] private Button settingsButton;
    //[SerializeField] private Button exitButton;
    //[SerializeField] private Button timerButton;
    //[SerializeField] private Button microphoneButton;


    // Center Text Field
    [SerializeField] private TMP_Text message;

    // Icons
    [SerializeField] private GameObject unmutedIcon;
    [SerializeField] private GameObject mutedIcon;

    private bool microphoneMuted = false;

    private void Start()
    {
        // Add listeners to buttons
        //lingoLinkButton.onClick.AddListener(LingoLinkButtonClicked);
        //translationMenuButton.onClick.AddListener(TranslationMenuButtonClicked);
        //settingsButton.onClick.AddListener(SettingsButtonClicked);
        //exitButton.onClick.AddListener(ExitSession);
        //timerButton.onClick.AddListener(TimerButtonClicked);
        //microphoneButton.onClick.AddListener(ToggleMicrophone);
    }

    private void ExitSession()
    {
        // Quit the application
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        #endif
    }

    private void ToggleMicrophone()
    {
        // Update icon visibility based on microphone state
        unmutedIcon.SetActive(false);
        mutedIcon.SetActive(true);
    }

    // Method for Lingo Link Button
    public void LingoLinkButtonClicked()
    {
        message.text = "Lingo Link";
        
        // Remove the line comments once we are ready to tie into timerMenu, and settingsMenu
        // timerMenu.SetActive(false);
        // settingsMenu.SetActive(false);
        translationMenu.SetActive(false);

        unmutedIcon.SetActive(true);
        mutedIcon.SetActive(false);
    }
    
    // Method for Translation Menu Button
    public void TranslationMenuButtonClicked()
    {
        // Toggle the Translation Menu
        translationMenu.SetActive(true);

        // Update UI message
        message.text = "Translate / Transcribe UI";
    }

    // Method for Settings Button
    public void SettingsButtonClicked()
    {
        // Toggle the settings menu
        settingsMenu.SetActive(true);
    }

    // Method for Timer Button
    public void TimerButtonClicked()
    {
        // Toggle the timer menu
        timerMenu.SetActive(true);
    }

    public void muteMic()
    {
        if (microphoneMuted)
        {
            microphoneMuted = true;
            mutedIcon.SetActive(true);
            unmutedIcon.SetActive(false);
            return;
        }
        microphoneMuted = !true;
        mutedIcon.SetActive(!true);
        unmutedIcon.SetActive(!false);

    }
}
