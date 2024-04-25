using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Canvas

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject translationMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject timerMenu;
    [SerializeField] private Realtime room;
    [SerializeField] private GameObject teleportMenu;


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
    [SerializeField] private GameObject micIcon;
    [SerializeField] private Sprite mutedIcon;
    [SerializeField] private Sprite unmutedIcon;
    private RealtimeAvatarVoice voice;

    public bool microphoneMuted = false;

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

     public void ToggleMicrophone()
    {
        
        microphoneMuted = !microphoneMuted;

        if (microphoneMuted)
        {
            micIcon.GetComponent<Image>().sprite = mutedIcon;
        }
        else
        {
            micIcon.GetComponent<Image>().sprite=unmutedIcon;
        }
        
    }

    // Method for Lingo Link Button
    public void LingoLinkButtonClicked()
    {

        message.text = "LINGO LINK";

        // Remove the line comments once we are ready to tie into timerMenu, and settingsMenu
        timerMenu.SetActive(false);
        settingsMenu.SetActive(false);
        translationMenu.SetActive(false);

        

        if (teleportMenu.activeInHierarchy)
        {
            teleportMenu.SetActive(false);
        }
        else
        {
            teleportMenu.SetActive(true);
            mainMenu.SetActive(false);
        }

        message.text = "TELEPORT";

        // Remove the line comments once we are ready to tie into timerMenu, and settingsMenu
        // timerMenu.SetActive(false);
        // settingsMenu.SetActive(false);
        //translationMenu.SetActive(false);

        //unmutedIcon.SetActive(true);
        //mutedIcon.SetActive(false);

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
            mainMenu.SetActive(false);
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
            mainMenu.SetActive(false);
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
            mainMenu.SetActive(false);
        }
    }

 

    public void goLobby()
    {
        room.Disconnect();
        room.Connect("Test Room");
        mainMenu.SetActive(true);
        FindObjectOfType<ButtonManager>().GameObject().SetActive(false);
    }
}
