using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject translationMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject timerMenu;
    [SerializeField] private Button microphoneButton;
    [SerializeField] private Button lingoLinkButton;
    [SerializeField] private Button translationMenuButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button timerButton;

    private bool microphoneMuted = false;

    private void Start()
    {
        // Add listeners to buttons
        exitButton.onClick.AddListener(ExitSession);
        microphoneButton.onClick.AddListener(ToggleMicrophone);
        lingoLinkButton.onClick.AddListener(LingoLinkButtonClicked);
        translationMenuButton.onClick.AddListener(TranslationMenuButtonClicked);
        settingsButton.onClick.AddListener(SettingsButtonClicked);
        timerButton.onClick.AddListener(TimerButtonClicked);
    }

    private void ExitSession()
    {
        // Quit the application
        Debug.Log("Exit Button Clicked");
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        #endif
    }

    private void ToggleMicrophone()
    {
        // Mute or unmute the microphone
        microphoneMuted = !microphoneMuted;
        // Code to mute/unmute microphone based on microphoneMuted variable
        if (microphoneMuted)
            Debug.Log("Microphone Muted");
        else
            Debug.Log("Microphone Unmuted");
    }

    // Method for Lingo Link Button
    public void LingoLinkButtonClicked()
    {
        // Your functionality here
        Debug.Log("Lingo Link Button Clicked");
    }

    // Method for Translation Menu Button
    public void TranslationMenuButtonClicked()
    {
        // Toggle the translation menu
        bool menuActive = translationMenu.activeSelf;
        translationMenu.SetActive(!menuActive);

        if (!menuActive)
            Debug.Log("Translation Menu Shown");
        else
            Debug.Log("Translation Menu Hidden");
    }

    // Method for Settings Button
    public void SettingsButtonClicked()
    {
        // Toggle the settings menu
        settingsMenu.SetActive(!settingsMenu.activeSelf);
        Debug.Log("Settings Button Clicked");
    }

    // Method for Timer Button
    public void TimerButtonClicked()
    {
        // Toggle the timer menu
        timerMenu.SetActive(!timerMenu.activeSelf);
        Debug.Log("Timer Button Clicked");
    }
}
