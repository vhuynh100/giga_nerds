using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateUI : MonoBehaviour
{
    public GameObject SuggestionsPopup;
    public GameObject SuggestionsButton;
    public TMP_Text ButtonText; //suggestions button text
    // Start is called before the first frame update

    //objects for suggestions
    public TMP_Text prompt1;
    public TMP_Text prompt2;

    void Start()
    {
        SuggestionsPopup.SetActive(false);
        SuggestionsButton.SetActive(true);
        /*^SuggestionsButton can be set to false if we want to 
         * enable true after recording and sending a transcript*/
    }

    public void requestSuggestions()
    {
        //change text to loading suggestions
        ButtonText.text = ("Loading Suggestions...");
        //call chatgpt for prompts
        
        //set text for two suggestions to what chatgpt  (in "Suggestions.cs" script)
        getSuggestions(); //just a placeholder function
        //hide button
        SuggestionsButton.SetActive(false);
        ButtonText.text = ("Request Suggestions");
        //show prompts
        SuggestionsPopup.SetActive(true);
    }
    public void getSuggestions() //could be changed with chatGPT calls/functions
    {
        prompt1.text = "This will be replaced with the chatGPT prompt. This will be replaced with the chatGPT prompt.";
        prompt2.text = "This will be the second prompt from chatGPT.";
    }

    public void closeSuggestions()
    {
        SuggestionsPopup.SetActive(false);
        SuggestionsButton.SetActive(true);
    }

    public void sendTranscript()
    {
        Debug.Log("Transcript button pressed.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
