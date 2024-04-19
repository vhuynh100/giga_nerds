using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public Slider audioVolume;
    public Slider microphoneVolume;
    public TMP_Dropdown microphones;
    public GameObject settingsMenu;
    public string activeMic;
    public float aVolume;
    public float mVolume;

    private List<TMP_Dropdown.OptionData> options;
    private int mPhones;


    private void Awake()
    {
        options = new List<TMP_Dropdown.OptionData>();
    }

    private void OnEnable()
    {
        mPhones = Microphone.devices.Length;

        if (mPhones > 1)
        {
            options.Clear();

            microphones.gameObject.SetActive(true);
            foreach (var mic in Microphone.devices)
            {
                var temp = new TMP_Dropdown.OptionData();
                temp.text = mic;
                options.Add(temp);
            }

            microphones.options = options;

        }
        else
        {
            microphones.gameObject.SetActive(false);
        }
    }


    public void chooseMic(TMP_Dropdown.OptionData choice)
    {
        activeMic = choice.text;
    }


    public void changeVol()
    {
        mVolume = microphoneVolume.value;
        aVolume = microphoneVolume.value;

        PlayerPrefs.SetFloat("volume", aVolume);
        PlayerPrefs.SetFloat("mic", mVolume);
    }

    public void returnToMain()
    {
        settingsMenu.SetActive(false);
        // add link to main menu gameobject
    }

}
