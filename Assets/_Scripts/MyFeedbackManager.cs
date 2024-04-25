using System;
using System.Collections.Generic;
using UnityEngine;

public class MyFeedbackManager : MonoBehaviour
{
    //public GameObject MainMenu;
    //public GameObject EndMenu;
    //public GameObject FeedbackMenu;

    //public string _player1Feedback = default;
    //public string _player2Feedback = default; 
    //private PlayerFeedback _playerFeedback;
    //private int playerNum = 0;

    public GameObject feedbackEntryPrefab; // Assign this prefab in the inspector
    public Transform feedbackContentPanel; // Assign the parent panel for feedback entries in the inspector

    private List<FeedbackEntry> feedbackEntries = new List<FeedbackEntry>();

    //private void Awake()  // DO NOT SET _playerFeedback INITIAL VARIABLE VALUES IN THIS Awake! only set initial variable values in PlayerFeedback.cs
    //{
    //    _playerFeedback = GetComponent<PlayerFeedback>();
    //}

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
        foreach (FeedbackEntry entry in feedbackEntries)
        {
            GameObject entryObject = Instantiate(feedbackEntryPrefab, feedbackContentPanel);

            InitFeedbackEntry feedbackEntry = entryObject.GetComponent<InitFeedbackEntry>();

            if (feedbackEntry != null)
            {
                feedbackEntry.Initialize(entry);
            }
        }
    }

    public void AddFeedbackEntry(FeedbackEntry entry)
    {
        feedbackEntries.Add(entry);
        FeedbackManager.WriteFeedback(entry);
        UpdateFeedbackDisplay();
    }

    private void Start()
    {
        //feedbackEntries = FeedbackManager.ReadFeedback();
        //UpdateFeedbackDisplay();
    }

    void Update()
    {
        // when Continue is clicked, feedback is sent to other player via SendFeedback()
        //if (playerNum == 0 & _playerFeedback.GetPlayer1Feedback() == "")
        //{
        //    playerNum = 1;
        //    _playerFeedback.SetPlayer1Feedback(feedback);
        //    UpdateFeedbackInMainMenu(feedback);
        //}
        //else if (playerNum == 0 & _playerFeedback.GetPlayer2Feedback() == "")
        //{
        //    playerNum = 2;
        //    _playerFeedback.SetPlayer2Feedback(feedback);
        //}
    }
}
