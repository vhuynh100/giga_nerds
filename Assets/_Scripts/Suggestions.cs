using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Suggestions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SuggestionUI;
    public TMP_Text prompt1;
    public TMP_Text prompt2;


    void Start()
    {
        //getSuggestions();
    }

    public void getSuggestions()
    {
        prompt1.text = "This will be replaced with the chatGPT prompt. This will be replaced with the chatGPT prompt.";
        prompt2.text = "This will be the second prompt from chatGPT.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
