using System;
using System.Collections.Generic;
using UnityEngine;

public class MyFeedbackManager : MonoBehaviour
{
    //public GameObject MainMenu;
    //public GameObject EndMenu;
    //public GameObject FeedbackMenu;

    public string _player1Feedback = "";
    public string _player2Feedback = "";
    private PlayerFeedback _playerFeedback;
    private int playerNum = 0;

    public GameObject feedbackEntryPrefab; // Assign this prefab in the inspector
    public Transform feedbackContentPanel; // Assign the parent panel for feedback entries in the inspector

    private List<string> feedbackEntries = new List<string>();

    private void Awake()  // DO NOT SET _playerFeedback INITIAL VARIABLE VALUES IN THIS Awake! only set initial variable values in PlayerFeedback.cs
    {
        _playerFeedback = GetComponent<PlayerFeedback>();
    }

    //public static void AddSampleFeedback()
    //{
    //    FeedbackEntry newFeedback = new FeedbackEntry(
    //        DateTime.Now, // This will still pass the full DateTime, but only the date will be stored.
    //        new List<string> { "Excellent Pronunciation", "Great Vocabulary" },
    //        5,
    //        "Pronunciation",
    //        "Great session, very informative!"
    //    );

    //    FeedbackManager.WriteFeedback(newFeedback);
    //    FeedbackManager.LogFeedbackData();
    //}

    //public static void AddSampleFeedback2()
    //{
    //    FeedbackEntry newFeedback = new FeedbackEntry(
    //        DateTime.Now, // This will still pass the full DateTime, but only the date will be stored.
    //        new List<string> { "testing" },
    //        3,
    //        "okk",
    //        "yay comments"
    //    );

    //    FeedbackManager.WriteFeedback(newFeedback);
    //    FeedbackManager.LogFeedbackData();
    //}

    // This would be called to update the feedback display
    public void UpdateFeedbackDisplay()
    {
        // Clear existing feedback entries
        foreach (Transform child in feedbackContentPanel)
        {
            Destroy(child.gameObject);
        }

        // Instantiate a new feedback entry prefab for each feedback entry
        foreach (string csvEntry in feedbackEntries)
        {
            FeedbackEntry entry = ParseCsvLine(csvEntry);

            GameObject entryObject = Instantiate(feedbackEntryPrefab, feedbackContentPanel);

            InitFeedbackEntry feedbackEntry = entryObject.GetComponent<InitFeedbackEntry>();

            if (feedbackEntry != null)
            {
                feedbackEntry.Initialize(entry);
            }
        }
    }

    public void AddFeedbackEntry(string csvEntry)
    {
        feedbackEntries.Add(csvEntry);
        //FeedbackManager.WriteFeedback(entry);
        UpdateFeedbackDisplay();
    }

    public static FeedbackEntry ParseCsvLine(string csvLine)
    {
        // Split the line into an array of fields
        var fields = ParseCsvFields(csvLine);

        if (fields.Length != 5)
        {
            throw new FormatException("CSV line does not contain the correct number of fields.");
        }

        DateTime feedbackDate = DateTime.Parse(fields[0]);
        int starRating = int.Parse(fields[1]);
        string sessionGoal = fields[2];
        string comment = fields[3];
        List<string> feedbackTags = new List<string>(fields[4].Split(';'));

        return new FeedbackEntry(feedbackDate, feedbackTags, starRating, sessionGoal, comment);
    }

    private static string[] ParseCsvFields(string csvLine)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string field = "";

        for (int i = 0; i < csvLine.Length; i++)
        {
            char c = csvLine[i];

            if (c == '"')
            {
                if (inQuotes && i < csvLine.Length - 1 && csvLine[i + 1] == '"')
                {
                    field += '"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(field);
                field = "";
            }
            else
            {
                field += c;
            }
        }

        fields.Add(field);

        return fields.ToArray();
    }

    private void Start()
    {
        //feedbackEntries = FeedbackManager.ReadFeedback();
        //UpdateFeedbackDisplay();

        if (playerNum == 0 & _playerFeedback.GetPlayer1Feedback() == "")
        {
            playerNum = 1;
        }
        else if (playerNum == 0 & _playerFeedback.GetPlayer2Feedback() == "")
        {
            playerNum = 2;
        }
    }

    void Update()
    {
        //Debug.Log(playerNum);
        if (playerNum == 1)
        {
            if (_playerFeedback.GetPlayer1Feedback() != _player1Feedback)
            {
                AddFeedbackEntry(_playerFeedback.GetPlayer1Feedback());
                _player1Feedback = _playerFeedback.GetPlayer1Feedback();
            }
        }
        else if (playerNum == 2)
        {
            if (_playerFeedback.GetPlayer2Feedback() != _player2Feedback)
            {
                AddFeedbackEntry(_playerFeedback.GetPlayer2Feedback());
                _player2Feedback = _playerFeedback.GetPlayer2Feedback();
            }
        }

        //Debug.Log("*** player 1 feedback:" + _playerFeedback.GetPlayer1Feedback());
        Debug.Log("*** player 2 feedback:" + _playerFeedback.GetPlayer2Feedback());
    }
}
