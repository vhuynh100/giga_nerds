using System;
using System.Collections.Generic;

[System.Serializable]
public class FeedbackEntry
{
    public string feedbackDate;
    public List<string> feedbackTags;
    public int starRating;
    public string sessionGoal;
    public string comment;

    public FeedbackEntry(DateTime date, List<string> tags, int rating, string goal, string comment)
    {
        feedbackDate = date.ToString("yyyy-MM-dd");
        feedbackTags = tags;
        starRating = rating;
        sessionGoal = goal;
        this.comment = comment;
    }
    public string ToCsvString()
    {
        string escapedComment = "\"" + comment.Replace("\"", "\"\"") + "\"";  // Escape quotes
        string tagsCombined = string.Join(";", feedbackTags);  // Combine tags with semicolon
        return $"{feedbackDate},{starRating},{sessionGoal},{escapedComment},{tagsCombined}";
    }
}

[System.Serializable]
public class FeedbackList
{
    public List<FeedbackEntry> feedback = new List<FeedbackEntry>();
}