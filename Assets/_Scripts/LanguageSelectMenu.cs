using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class LanguageSelectMenu : MonoBehaviour
{
    public GameObject Menu1;
    public GameObject Menu2;
    public GameObject alertLanguage;
    public TMP_Text alertText;
    public GameObject MainMenu;
    public GameObject languageSelect;

    public MatchMakingController mm;
    public LocaleSelector ls;

    private bool isLangSelected = false;
    public string fluentLanguage; //where the first language selection will be saved
    public string practiceLanguage; //where the second language selection will be saved


    void Start()
    {
        Menu1.SetActive(true);
        alertLanguage.SetActive(false);
        Menu2.SetActive(false);

    }

    void OnLangSelected()
    //if the selection is true then allows to move to next menu
    {
        isLangSelected = true;
        alertLanguage.SetActive(false);
    }

    public void setLanguage(string language)
    //checks if the language is valid to set variable from first menu (fluent)
    {
        if (language == "invalid")
        {
            isLangSelected = false;
        }
        else
        {
            fluentLanguage = language;
            OnLangSelected();
            switch (language)
            {
                case "English": ls.ChangeLocale(0); mm.SetPlayerLanguageEnglish(); break;
                case "Spanish": ls.ChangeLocale(1); mm.SetPlayerLanguageSpanish(); break;
            }
        }
    }

    public void setLearningLang(string language)
    //checks if the language is valid to set variable from second menu (practice)
    {
        if (language == "invalid" || language == fluentLanguage)
        {
            isLangSelected = false;
            alertLanguage.SetActive(true);
        }
        else
        {
            practiceLanguage = language;
            OnLangSelected();
            // switch (language)
            // {
            //     case "English": ls.ChangeLocale(0); mm.SetPlayerLanguageEnglish(); break;
            //     case "Spanish": ls.ChangeLocale(1); mm.SetPlayerLanguageSpanish(); break;
            // }
        }
    }


    public void nextMenu()
    //checks if last selection is a valid language to change the menus
    {
        if (isLangSelected)
        {
            Menu1.SetActive(false);
            Menu2.SetActive(true);
            alertText.text = "Please select a valid language.\n\nLanguage fluent in: " + fluentLanguage;
            isLangSelected = false; //to check next menu
            Debug.Log("Language selected: " + fluentLanguage);
        }
        else
        {
            Debug.Log("Language not selected");
            alertLanguage.SetActive(true);
        }
    }

    public void closeMenu()
    //checks if last selection is a valid language to close the menu
    {
        if (isLangSelected)
        {
            Menu2.SetActive(false);
            languageSelect.SetActive(false);
            MainMenu.SetActive(true);
            Debug.Log("Second Language selected: " + practiceLanguage);
        }
        else
        {
            Debug.Log("Second Language not selected");
            alertLanguage.SetActive(true);
        }
    }

}
