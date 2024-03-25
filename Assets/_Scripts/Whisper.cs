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

        [SerializeField] private string _translationString = default;
        [SerializeField] private string _previousTranslationString = default;
        [SerializeField] private bool _requested = default;

        private RequestSync _requestSync;
        //private int starting = 0;

        private string messageString;

        private readonly string fileName = "output.wav";
        private readonly int duration = 5;



        private AudioClip clip;
        private bool isRecording;
        private float time;
        private OpenAIApi openai = new OpenAIApi();
        private string targetLanguage = "es"; // Default target language is Spanish
        private bool madeRequest = false;
        private bool recievedRequest = false;

        private void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            dropdown.options.Add(new Dropdown.OptionData("Microphone not supported on WebGL"));

#else


            

            foreach (var device in Microphone.devices)
            {
                dropdown.options.Add(new Dropdown.OptionData(device));
            }

            recordButton.onClick.AddListener(MakeRequest);  // was initially AddListener(StartRecording)
            dropdown.onValueChanged.AddListener(ChangeMicrophone);

            spanishButton.onClick.AddListener(() => SetTargetLanguage("es"));
            frenchButton.onClick.AddListener(() => SetTargetLanguage("fr"));
            germanButton.onClick.AddListener(() => SetTargetLanguage("de"));
                
            //SetTargetLanguage("es");                                                                                                  // these 2 lines can be uncommented for use of testing on meta simulator
            //PlayerPrefs.SetInt("user-mic-device-index", 1);

            var index = PlayerPrefs.GetInt("user-mic-device-index");
            dropdown.SetValueWithoutNotify(index);

            
#endif
        }

        private void Awake()  // DO NOT SET _requestSync INITIAL VARIABLE VALUES IN THIS Awake! only set initial variable values in RequestSync.cs
        {
            _requestSync = GetComponent<RequestSync>();
        }

        private void ChangeMicrophone(int index)
        {
            PlayerPrefs.SetInt("user-mic-device-index", index);//initually it was set to index instead of 1
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

        private void MakeRequest()
        {
            recievedRequest = false;
            if (_requestSync.GetRequested() == false) {
                madeRequest = true;
                _requestSync.SetRequested(true);
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
            _translationString = $"{targetLanguage.ToUpper()}: {res.Text}";
            _requestSync.SetTranslation(_translationString);
            message.text = "Translation sucessfully sent";
            recievedRequest = true;
            recordButton.enabled = true;
        }

        private void Update()
        {

            print("====================================================================================================================================== Made Request: " + madeRequest);
            print("======================================================================================================================================= Request Sync Request: " + _requestSync.GetRequested());
            print("====================================================================================================================================== Request Sync translation: " + _requestSync.GetTranslation());
            print("======================================================================================================================================== translationString: " + _translationString);
            //starting = starting + 1;
            //if( starting == 100)
            //{
                //print("-------------------------------------------------------- request automatically sent");
                //MakeRequest();

            //}

            if (!isRecording && _requestSync.GetRequested() == true && madeRequest == false)  // translation request was recieved, starts recording
            {
                print("============================================================================================================= Recording was requested");
                StartRecording();
            }


            if(madeRequest == true && recievedRequest == true && message.text != _requestSync.GetTranslation()) // translation requested and recieved, displays new translation and sets shared request status to false.
            {
                message.text = _requestSync.GetTranslation();
                _requestSync.SetRequested(false);
                recievedRequest = false;
                madeRequest = false;
            }

            if (madeRequest == false && _translationString != _requestSync.GetTranslation()) // someone requested a translation and it was generated.
            {                                                       
                _requestSync.SetTranslation(_translationString);
                _requestSync.SetRequested(false);
            }

            if (madeRequest == true && _requestSync.GetTranslation() != _translationString)  // you requested a translation and it was recieved.
            {
                message.text = _requestSync.GetTranslation();
                _translationString = _requestSync.GetTranslation();
                _previousTranslationString = _translationString;
                _requestSync.SetRequested(false);
                madeRequest = false;
            }


            if (isRecording)
            {
                time += Time.deltaTime;
                progressBar.fillAmount = time / duration;

                if (time >= duration)
                {
                    time = 0;
                    isRecording = false;
                    _requestSync.SetRequested(false);
                    EndRecording();
                    recievedRequest = true;
                }
            }
        }
    }
}
