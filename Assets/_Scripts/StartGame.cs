using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartGameButton : MonoBehaviour
{
    public Color targetColor = Color.red; // Set the desired color in the inspector

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Replace the following line with the logic to change the color of the Unity object
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = targetColor;
            Debug.Log("Color changed to " + targetColor);
        }
        else
        {
            Debug.LogWarning("Renderer component not found on the Unity object.");
        }
    }
}
