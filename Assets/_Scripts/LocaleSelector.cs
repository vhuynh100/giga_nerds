using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Localization.Editor;
using UnityEngine;

using UnityEngine.Localization.Settings;
public class LocaleSelector : MonoBehaviour
{
    private bool active = false;
    public void ChangeLocale(int localeID) {
        if(active == true) {
            return;
        }
        StartCoroutine(SetLocale(localeID));
    }
    IEnumerator SetLocale(int _localeID) {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }
    // public void SetEnglishLanguage()
    // {
    //     SetLocalizationLanguage("en");
    // }

    // public void SetSpanishLanguage()
    // {
    //     SetLocalizationLanguage("es");
    // }

    // private void SetLocalizationLanguage(string languageCode)
    // {
    //     // Set the selected language
    //     LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(languageCode);
    // }
}
