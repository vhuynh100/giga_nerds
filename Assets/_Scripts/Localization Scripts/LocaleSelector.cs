using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Editor;
using UnityEngine;

using UnityEngine.Localization.Settings;
public class LocaleSelector : MonoBehaviour
{
    public void ChangeDefaultLanguage(int localeID) {
        PlayerPrefs.SetInt("DefaultLanguage", localeID);
        PlayerPrefs.Save();
    }

    public void ChangeLearningLanguage(int localeID)
    {
        PlayerPrefs.SetInt("LearningLanguage", localeID);
        PlayerPrefs.Save();
    }
    // private bool active = false;
    // private const string DefaultLanguageKey = "DefaultLanguage";
    // private const string LearningLanguageKey = "LearningLanguage";

    // // Default language ID and learning language ID
    // private int defaultLanguageID = 0; // Default to the first language
    // private int learningLanguageID = 0; // Default to the first language

    // public int GetLearningLanguageID => learningLanguageID;
    // public int GetDefaultLanguageID => defaultLanguageID;

    // private void Start()
    // {
    //     // Load saved language selections if they exist
    //     if (PlayerPrefs.HasKey(DefaultLanguageKey))
    //     {
    //         defaultLanguageID = PlayerPrefs.GetInt(DefaultLanguageKey);
    //     }
    //     if (PlayerPrefs.HasKey(LearningLanguageKey))
    //     {
    //         learningLanguageID = PlayerPrefs.GetInt(LearningLanguageKey);
    //     }

    //     // Set the initial locale based on the saved selections
    //     StartCoroutine(SetLocales(defaultLanguageID, learningLanguageID));
    // }

    // public void ChangeDefaultLanguage(int localeID)
    // {
    //     defaultLanguageID = localeID;
    //     // Save the selected default language
    //     PlayerPrefs.SetInt(DefaultLanguageKey, defaultLanguageID);
    //     PlayerPrefs.Save();
    //     StartCoroutine(SetLocales(defaultLanguageID, learningLanguageID));
    // }

    // public void ChangeLearningLanguage(int localeID)
    // {
    //     learningLanguageID = localeID;

    //     // Save the selected learning language
    //     PlayerPrefs.SetInt(LearningLanguageKey, learningLanguageID);
    //     PlayerPrefs.Save();
    //     StartCoroutine(SetLocales(defaultLanguageID, learningLanguageID));
    // }

    // IEnumerator SetLocales(int defaultLocaleID, int learningLocaleID)
    // {
    //     // if (active) yield break;

    //     // active = true;
    //     yield return LocalizationSettings.InitializationOperation;

    //     // Set the default language
    //     LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[defaultLocaleID];
    //     LocalizationSettings.SelectedLocaleAsync = LocalizationSettings.AvailableLocales.Locales[learningLocaleID];

    //     // Set the learning language
    //     // Note: You might have different logic here depending on how you handle objects in different languages
    //     // For demonstration purposes, let's say you're just switching the language for all objects
    //     // foreach (var obj in FindObjectsOfType<SetCanvasNameFromItem>())
    //     // {
    //     //     obj.TranslateText(learningLocaleID);
    //     // }

    //     // active = false;
    // }
}
