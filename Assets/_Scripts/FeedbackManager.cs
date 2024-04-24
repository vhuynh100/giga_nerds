using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FeedbackManager
{
    private static string feedbackFilePath = Path.Combine(Application.persistentDataPath, "feedback.json");

    public static void WriteFeedback(FeedbackEntry feedbackEntry)
    {
        FeedbackList feedbackList;

        if (File.Exists(feedbackFilePath))
        {
            string dataAsJson = File.ReadAllText(feedbackFilePath);
            feedbackList = JsonUtility.FromJson<FeedbackList>(dataAsJson);
        }
        else
        {
            feedbackList = new FeedbackList();
        }

        feedbackList.feedback.Add(feedbackEntry);
        string json = JsonUtility.ToJson(feedbackList, true);
        File.WriteAllText(feedbackFilePath, json);
    }

    public static List<FeedbackEntry> ReadFeedback()
    {
        if (File.Exists(feedbackFilePath))
        {
            string dataAsJson = File.ReadAllText(feedbackFilePath);
            FeedbackList feedbackList = JsonUtility.FromJson<FeedbackList>(dataAsJson);
            return feedbackList.feedback;
        }
        return new List<FeedbackEntry>();
    }
}
