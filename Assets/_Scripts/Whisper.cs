using OpenAI;
using UnityEngine;
using UnityEngine.UI;

namespace Samples.Whisper
{
    public class Whisper : MonoBehaviour
    {
        [SerializeField] private Button recordButton;
        [SerializeField] private Button spanishButton;
        [SerializeField] private Button frenchButton;
        [SerializeField] private Button germanButton;
        [SerializeField] private Image progressBar;
        [SerializeField] private Text message;
        [SerializeField] private Dropdown dropdown;

        [SerializeField] private Color activeButtonColor = new Color(0.5f, 0.5f, 0.5f); // Define the color for active buttons

        private readonly string fileName = "output.wav";
        private readonly int duration = 5;

        private AudioClip clip;
        private bool isRecording;
        private float time;
        private OpenAIApi openai = new OpenAIApi();
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
            recordButton.onClick.AddListener(StartRecording);
            dropdown.onValueChanged.AddListener(ChangeMicrophone);

            spanishButton.onClick.AddListener(() => SetTargetLanguage("es"));
            frenchButton.onClick.AddListener(() => SetTargetLanguage("fr"));
            germanButton.onClick.AddListener(() => SetTargetLanguage("de"));

            var index = PlayerPrefs.GetInt("user-mic-device-index");
            dropdown.SetValueWithoutNotify(index);
#endif
        }

        private void ChangeMicrophone(int index)
        {
            PlayerPrefs.SetInt("user-mic-device-index", index);
        }

        private void SetTargetLanguage(string language)
        {
            targetLanguage = language;

            // Reset all buttons to default color
            spanishButton.GetComponent<Image>().color = Color.white;
            frenchButton.GetComponent<Image>().color = Color.white;
            germanButton.GetComponent<Image>().color = Color.white;

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

        private void StartRecording()
        {
            isRecording = true;
            recordButton.enabled = false;

            var index = PlayerPrefs.GetInt("user-mic-device-index");

#if !UNITY_WEBGL
            clip = Microphone.Start(dropdown.options[index].text, false, duration, 44100);
#endif
        }

        private async void EndRecording()
        {
            message.text = "Waiting on OpenAI...";

#if !UNITY_WEBGL
            Microphone.End(null);
#endif

            byte[] data = SaveWav.Save(fileName, clip);

            // API Request to OpenAI
            var req = new CreateAudioTranscriptionsRequest
            {
                FileData = new FileData() { Data = data, Name = "audio.wav" },
                Model = "whisper-1", // Set the model
                Language = targetLanguage // Set the language to the target language
            };
            var res = await openai.CreateAudioTranscription(req);

            progressBar.fillAmount = 0;

            // Display API text to UI
            message.text = $"{targetLanguage.ToUpper()}: {res.Text}";
            recordButton.enabled = true;
        }

        private void Update()
        {
            if (isRecording)
            {
                time += Time.deltaTime;
                progressBar.fillAmount = time / duration;

                if (time >= duration)
                {
                    time = 0;
                    isRecording = false;
                    EndRecording();
                }
            }
        }
    }
}
