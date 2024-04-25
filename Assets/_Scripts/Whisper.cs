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

        [SerializeField] private GameObject translateUI;

        [SerializeField] private Color activeButtonColor = new Color(0.5f, 0.5f, 0.5f); // Define the color for active buttons

        [SerializeField] private string _translationString = default;
        [SerializeField] private string _previousTranslationString = default;
        [SerializeField] private bool _requested = default;
        [SerializeField] private MatchMaking matchMakingController;

        [SerializeField] private ChatGPT chatgpt;


        private string translationLog = "";



        private RequestSync _requestSync;
        private int starting = 0;

        private string messageString;

        private readonly string fileName = "output.wav";
        private readonly int duration = 5;



        private AudioClip clip;
        private bool isRecording;
        private float time;
        private OpenAIApi openai = new OpenAIApi();
        private string targetLanguage = ""; // Default target language is Spanish
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

            //spanishButton.onClick.AddListener(() => SetTargetLanguage("es"));
            //frenchButton.onClick.AddListener(() => SetTargetLanguage("fr"));
            //germanButton.onClick.AddListener(() => SetTargetLanguage("de"));
                
            //SetTargetLanguage("de");                                                                                                  // these 2 lines can be uncommented for use of testing on meta simulator
            PlayerPrefs.SetInt("user-mic-device-index", 1);

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
            PlayerPrefs.SetInt("user-mic-device-index", 1);//initually it was set to index instead of 1
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


        private string AddTranslationToLog(string existingTranslationLog, string newTranslation)
        {
            print("=== existingTranslationString" + existingTranslationLog);
            print("=== newTranslation" + newTranslation);
             return newTranslation +"\n\n"+ existingTranslationLog;
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

            translateUI.SetActive(true);
            isRecording = true;
            recordButton.enabled = false;

            var index = PlayerPrefs.GetInt("user-mic-device-index");

#if !UNITY_WEBGL
            clip = Microphone.Start(dropdown.options[index].text, false, duration, 44100);
#endif
        }

        private async void EndRecording()
        {
            //message.text = "Waiting on OpenAI...";

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
            //message.text = "Translation sucessfully sent";
            
            recievedRequest = true;
            recordButton.enabled = true;
        }

        private bool EmptyTranslation(string translationString)
        {
            string advertisement = "Amara.org";

            if (translationString.Contains(advertisement))
            {
                return true;
            }

            return false;
        }


        private void SendTranslatedText(string translatedText)
        {
            //ChatGPT chatGPTScript = FindObjectOfType<ChatGPT>();
            chatgpt.ReceiveTranslatedText(translatedText);

        }



        private void Update()
        {

            //print("====================================================================================================================================== Made Request: " + madeRequest);
            //print("======================================================================================================================================= Request Sync Request: " + _requestSync.GetRequested());
            //print("====================================================================================================================================== Request Sync translation: " + _requestSync.GetTranslation());
            //print("======================================================================================================================================== translationString: " + _translationString);
            //starting = starting + 1;
            //if( starting == 100)
            //{
            // print("-------------------------------------------------------- request automatically sent");
            //MakeRequest();

            //}
            //print("===== User Language = " + matchMakingController.GetUserLanguage());
            if (targetLanguage == "")
            {
                matchMakingController.GetUserLanguage();
            }



            if (targetLanguage == "en" || targetLanguage == "es")
            {
                print("==== player language set");
                if (!isRecording && _requestSync.GetRequested() == true && madeRequest == false)  // translation request was recieved, starts recording
                {
                    print("============================================================================================================= Recording was requested");
                    StartRecording();
                }


                if (madeRequest == true && recievedRequest == true && _translationString != _requestSync.GetTranslation()) // translation requested and recieved, displays new translation and sets shared request status to false.
                {
                    if (!EmptyTranslation(_requestSync.GetTranslation()))
                    {
                        translationLog = AddTranslationToLog(translationLog, _requestSync.GetTranslation());
                        print("======== requestSync: " + _requestSync.GetTranslation());
                        print("======= translationLog: " + translationLog);
                        message.text = translationLog;
                        SendTranslatedText(message.text);
                    }
                    else
                    {

                        translationLog = AddTranslationToLog(translationLog, "No translation recorded.");
                        message.text = translationLog;
                    }

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
                    if (!EmptyTranslation(_requestSync.GetTranslation()))
                    {
                        translationLog = AddTranslationToLog(translationLog, _requestSync.GetTranslation());
                        print("======== requestSync: " + _requestSync.GetTranslation());
                        print("======= translationLog: " + translationLog);
                        message.text = translationLog;
                        SendTranslatedText(message.text);
                    }
                    else
                    {
                        translationLog = AddTranslationToLog(translationLog, "No translation was recorded");
                        print("======== requestSync: " + _requestSync.GetTranslation());
                        print("======= translationLog: " + translationLog);
                        message.text = translationLog;
                        SendTranslatedText(message.text);
                    }
                    _translationString = _requestSync.GetTranslation();
                    _previousTranslationString = _translationString;
                    _requestSync.SetRequested(false);
                    madeRequest = false;
                }
            } else if (matchMakingController.GetUserLanguage() == "en")
            {
                print("====== player language set to english");
                targetLanguage = "es";
            } else if (matchMakingController.GetUserLanguage() == "es")
            {
                print("==== player language set to spanish");
                targetLanguage = "en";
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
