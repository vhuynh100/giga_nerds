using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Handles reading and writing feedback JSON files
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

    public static void LogFeedbackData()
    {

        string path = Path.Combine(Application.persistentDataPath, "feedback.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            Debug.Log("*** Feedback Data: " + jsonData);
        }
        else
        {
            Debug.LogWarning("Feedback file does not exist.");
        }
    }

    public static void ClearFeedbackEntries()
    {
        string path = Path.Combine(Application.persistentDataPath, "feedback.json");
        FeedbackList feedbackList = new FeedbackList(); // Creates an empty list
        string emptyJson = JsonUtility.ToJson(feedbackList, true);
        File.WriteAllText(path, emptyJson); // Overwrites the file with an empty list
    }

    public static void DeleteFeedbackFile()
    {
        string path = Path.Combine(Application.persistentDataPath, "feedback.json");
        if (File.Exists(path))
        {
            File.Delete(path); // Deletes the file
        }
    }
}
