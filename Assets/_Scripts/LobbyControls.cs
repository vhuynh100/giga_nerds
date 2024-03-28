using OpenAI;
using UnityEngine;
using UnityEngine.UI;

namespace Samples.Whisper
{
    public class LobbyControls : MonoBehaviour
    {
        [SerializeField] private Button recordButton;
        [SerializeField] private Button spanishButton;
        [SerializeField] private Button frenchButton;
        [SerializeField] private Button germanButton;
        [SerializeField] private Image progressBar;
        [SerializeField] private Text message;
        [SerializeField] private Dropdown dropdown;

        [SerializeField] private Color activeButtonColor = new Color(0.5f, 0.5f, 0.5f); // Define the color for active buttons

        [SerializeField] private string _translationString = default;
        [SerializeField] private string _previousTranslationString = default;
        [SerializeField] private bool _requested = default;



        private string targetLanguage = "es"; // Default target language is Spanish
        

        private void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            dropdown.options.Add(new Dropdown.OptionData("Microphone not supported on WebGL"));

#else

            foreach (var device in Microphone.devices)
            {
                dropdown.options.Add(new Dropdown.OptionData(device));
            }

            spanishButton.onClick.AddListener(() => SetTargetLanguage("es"));
            frenchButton.onClick.AddListener(() => SetTargetLanguage("fr"));
            germanButton.onClick.AddListener(() => SetTargetLanguage("de"));

            var index = PlayerPrefs.GetInt("user-mic-device-index");
            dropdown.SetValueWithoutNotify(index);


#endif
        }

        private void SetTargetLanguage(string language)
        {
            targetLanguage = language;

            // Reset all buttons to default color
            spanishButton.GetComponent<Image>().color = Color.white;
            frenchButton.GetComponent<Image>().color = Color.white;
            germanButton.GetComponent<Image>().color = Color.white;

            language = "es";

            // Set the active button to the darker color
            switch (language)
            {
                case "es":
                    spanishButton.GetComponent<Image>().color = activeButtonColor;
                    break;
                case "fr":
                    frenchButton.GetComponent<Image>().color = activeButtonColor;
                    break;
                case "de":
                    germanButton.GetComponent<Image>().color = activeButtonColor;
                    break;
            }
        }

        private void Update()
        {

            
        }
    }
}
