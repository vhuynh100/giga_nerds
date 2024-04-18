using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{



    public GameObject language;
    public GameObject mainMenu;
    public GameObject credits;
    //public MatchMaking mm;

    //Object to instantiate for each language;

    //User choice variable
    //string userChoice;



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            AudioListener.volume = .5f;
            PlayerPrefs.SetFloat("volume", .5f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Screen swapping
    public void langSelect()
    {
        language.SetActive(true);
        mainMenu.SetActive(false);

    }
    public void enterCredits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void leaveCredits()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void exitApplication()
    {
        Application.Quit();
    }

}
