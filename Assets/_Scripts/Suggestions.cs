using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;
namespace OpenAI
{ 
public class Suggestions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SuggestionUI;
    public TMP_Text suggestionDisplay1;
    public TMP_Text suggestionDisplay2;
    private string message;


    [SerializeField] private Button GetSuggestions;

    private OpenAIApi openai = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();
    private string prompt = "Act as a random stranger in a chat room and reply to the questions. Don't break character. Don't ever mention that you are an AI model. Respond with two suggestions for the conversation being sent to you in the same language.";

    private void Start()
    {
        GetSuggestions.onClick.AddListener(SendReply);
    }

    private async void SendReply()
    {
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
            var suggestionsText = completionResponse.Choices[0].Message.Content.Trim();

            // Define delimiters as characters instead of strings
            char[] delimiters = { '1', '2', '.' };

            // Split the suggestions based on the delimiters
            string[] suggestions = suggestionsText.Split(delimiters);

            // Filter out empty entries
            suggestions = suggestions.Where(s => !string.IsNullOrEmpty(s.Trim())).ToArray();

            if (suggestions.Length >= 2)
            {
                suggestionDisplay1.text = suggestions[0].Trim(); // Index 0 corresponds to the first suggestion after "1."
                suggestionDisplay2.text = suggestions[1].Trim(); // Index 1 corresponds to the second suggestion after "2."
            }
            else if (suggestions.Length == 1)
            {
                suggestionDisplay1.text = suggestions[0].Trim(); // Only one suggestion available
                suggestionDisplay2.text = "No second suggestion available.";
            }
            else
            {
                Debug.LogWarning("No suggestions were found.");
                suggestionDisplay1.text = "No suggestions were found.";
                suggestionDisplay2.text = "No suggestions were found.";
            }
        }
        else
        {
            Debug.LogWarning("No text was generated from this prompt.");
            suggestionDisplay1.text = "No text was generated from this prompt.";
            suggestionDisplay2.text = "No text was generated from this prompt.";
        }
    }

    // This method is called from the Whisper script to pass translated text
    public void ReceiveTranslatedText(string translatedText)
    {
        // Set the Message variable with the translated text
        message = translatedText;
        // Call SendReply to process the translated text and generate suggestions

    }
}
}

