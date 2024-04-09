using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetCanvasNameFromItem : MonoBehaviour
{
    public GameObject referenced;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        //need way to translate referenced.name to another language
        text.text = referenced.name;
    }
}
