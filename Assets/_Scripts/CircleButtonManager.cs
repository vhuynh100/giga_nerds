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
        message.text = "LINGO LINK";
        
        // Remove the line comments once we are ready to tie into timerMenu, and settingsMenu
        // timerMenu.SetActive(false);
        // settingsMenu.SetActive(false);
        translationMenu.SetActive(false);

        unmutedIcon.SetActive(true);
        mutedIcon.SetActive(false);
    }
    
    public void TranslationMenuButtonClicked()
    {
        if (translationMenu.activeInHierarchy)
        {
            translationMenu.SetActive(false);
        }
        else
        {
            translationMenu.SetActive(true);
        }

        message.text = "TRANSLATE";
    }

    public void SettingsButtonClicked()
    {
        if (settingsMenu.activeInHierarchy)
        {
            settingsMenu.SetActive(false);
        }
        else
        {
            settingsMenu.SetActive(true);
        }
    }

    public void TimerButtonClicked()
    {
        if (timerMenu.activeInHierarchy)
        {
            timerMenu.SetActive(false);
        }
        else
        {
            timerMenu.SetActive(true);
        }
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
