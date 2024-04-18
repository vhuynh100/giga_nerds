using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class langSelectLocalization : MonoBehaviour
{
    public TMP_Text englishB;
    public TMP_Text spanishB;
    public MainMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("language"))
        {
            englishB.text = "English";
            spanishB.text = "Spanish";
        }

        else if(PlayerPrefs.GetString("language") == "English")
        {
            englishB.text = "English";
            spanishB.text = "Spanish";
        }
        else if (PlayerPrefs.GetString("language") == "Spanish")
        {
            englishB.text = "Ingles";
            spanishB.text = "Español";
        }
    }

   public void changeSpanish()
    {
        PlayerPrefs.SetString("language", "Spanish");
        englishB.text = "Ingles";
        spanishB.text = "Español";
        
    }
    public void changeEnglish()
    {
        PlayerPrefs.SetString("language", "English");
        englishB.text = "English";
        spanishB.text = "Spanish";
        
    }
    
    public void backButton()
    {
        menu.mainMenu.SetActive(true);
        menu.language.SetActive(false);
    }
}
