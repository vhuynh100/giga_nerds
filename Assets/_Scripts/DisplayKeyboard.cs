using UnityEngine;
using UnityEngine.UI;

public class DisplayKeyboard : MonoBehaviour
{
    public InputField inputField;
    [SerializeField] private GameObject virtualKeyboard;

    void Start()
    {
        // You can put initialization code here if needed.
    }

    public void ShowKeyboardButtonClicked()
    {
        // Toggle the visibility of the virtual keyboard.
        virtualKeyboard.SetActive(!virtualKeyboard.activeSelf);
    }
}
