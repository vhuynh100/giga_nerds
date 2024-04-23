using System.Collections;
using System.Collections.Generic;

// using Meta.WitAi.Drawers;

using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class SetCanvasNameFromItem : MonoBehaviour
{
    public GameObject referenced;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateLocalization();
    }

    void Update()
    {
        // Check if the user's language preference has changed
        if (LocalizationSettings.SelectedLocale != GetOverrideLocale())
        {
            UpdateLocalization();
        }
    }

    void UpdateLocalization()
    {
        // Apply language override if necessary
        ApplyLanguageOverride();

        // Get the localized string for the key from the specified table
        LocalizedString localizedString = new LocalizedString { TableReference = "LocaleTable", TableEntryReference = referenced.name };

        // Override the language for this specific localized string
        localizedString.LocaleOverride = GetOverrideLocale();

        localizedString.RefreshString();

        // Get the translation
        string translation = localizedString.GetLocalizedString();

        Debug.Log("Translation for key " + referenced.name + ": " + translation);
        text.text = translation;
    }

    void ApplyLanguageOverride()
    {
        Locale overrideLocale = GetOverrideLocale();
        if (LocalizationSettings.SelectedLocale != overrideLocale)
        {
            LocalizationSettings.SelectedLocale = overrideLocale;
        }
    }

    Locale GetOverrideLocale()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            return LocalizationSettings.AvailableLocales.GetLocale(SystemLanguage.Spanish);
        }
        else if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            return LocalizationSettings.AvailableLocales.GetLocale(SystemLanguage.English);
        }
        else
        {
            return LocalizationSettings.SelectedLocale;
        }
    }



}
