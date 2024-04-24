using System;
using System.Collections.Generic;

[System.Serializable]
public class FeedbackEntry
{
    public string feedbackDate;
    public string[] feedbackTags;
    public int starRating;
    public string sessionGoal;
    public string comment;

    public FeedbackEntry(DateTime date, string[] tags, int rating, string goal, string comment)
    {
        feedbackDate = date.ToString("yyyy-MM-dd");
        feedbackTags = tags;
        starRating = rating;
        sessionGoal = goal;
        this.comment = comment;
    }
}

[System.Serializable]
public class FeedbackList
{
    public List<FeedbackEntry> feedback = new List<FeedbackEntry>();
}