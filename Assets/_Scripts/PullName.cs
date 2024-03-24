using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PullName : MonoBehaviour
{
    public GameObject referenced;
    public TextMeshProUGUI text;
    private void OnEnable()
    {
        text.text = referenced.name;  
        // need something to translate referenced name to other language
    }
}
