using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
         //private Text Message;

        private string message;
        //[SerializeField] private RectTransform received1;
        //[SerializeField] private RectTransform received2;

        [SerializeField] private TMP_Text suggestionDisplay1;
        [SerializeField] private TMP_Text suggestionDisplay2;

        private OpenAIApi openai = new OpenAIApi();
        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "Act as a random stranger in a chat room and reply to the questions. Don't break character. Don't ever mention that you are an AI model. Respond with two suggestions for the conversation being sent to you.";

        private void Start()
        {
            // Initialize the Message variable if it's not already initialized
            //if (Message == null)
                //Message = GetComponentInChildren<Text>();
        }

       private async void SendReply()
        {
            print("====== sending reply");
            //var translatedText = Message.text;
            var translatedText = message;


            
            // Create a new ChatMessage instance
            var newMessage = new ChatMessage() { Role = "user", Content = translatedText };

            // Check if it's the first message and append the prompt if so
            if (messages.Count == 0)
                newMessage.Content = prompt + "\n" + translatedText; 

            // Add the new message to the messages list
            messages.Add(newMessage);

            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo-0613",
                Messages = messages
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var suggestion1 = completionResponse.Choices[0].Message.Content.Trim();
                //var suggestion2 = completionResponse.Choices[1].Message.Content.Trim();
                print("======== suggestion 1: " + suggestion1);

                //received1.GetComponentInChildren<Text>().text = suggestion1;
                //received2.GetComponentInChildren<Text>().text = suggestion2;

                suggestionDisplay1.text = suggestion1;
                //suggestionDisplay2.text = suggestion2;


            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
                //received1.GetComponentInChildren<Text>().text = "No text was generated from this prompt.";
                //received2.GetComponentInChildren<Text>().text = "No text was generated from this prompt.";

                suggestionDisplay1.text = "No text was generated from this prompt.";
                suggestionDisplay2.text = "No text was generated from this prompt.";
            }
        }

        // This method is called from the Whisper script to pass translated text
        public void ReceiveTranslatedText(string translatedText)
        {
            // Set the Message variable with the translated text

            print("=== recieveing translated text: " + translatedText);
            message = translatedText;
            //Message.text = translatedText;
            // Call SendReply to process the translated text and generate suggestions
            SendReply();
        }
    }
}
