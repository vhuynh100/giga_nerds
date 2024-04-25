using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 50f; 
    private Image image;

    void Start()
    {
        // gets GameObject image
        image = GetComponent<Image>();
    }

    void Update()
    {
        // rotate image around z axis
        image.rectTransform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }
}
