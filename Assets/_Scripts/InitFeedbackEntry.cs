using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitFeedbackEntry : MonoBehaviour
{
    public TMP_Text dateText;
    public TMP_Text goalText;
    public TMP_Text commentText;
    private List<string> tagStrings = new List<string>();
    private int starRating;
    public GameObject[] tags;
    public Image[] stars;

    public Sprite selectedStarSprite;
    public Sprite unselectedStarSprite;

    // Call this method to populate the entry data
    public void Initialize(FeedbackEntry entry)
    {
        dateText.text = entry.feedbackDate;
        goalText.text = entry.sessionGoal;
        commentText.text = entry.comment;
        tagStrings = entry.feedbackTags;
        starRating = entry.starRating;

        SetStarRating(starRating);

        foreach (var tag in tags)
        {
            tag.SetActive(false); // Reset first
        }

        foreach (string tag in tagStrings)
        {
            if (tag == "Pronunciation") tags[0].SetActive(true);
            else if (tag == "Vocabulary") tags[1].SetActive(true);
            else if (tag == "Articulation") tags[2].SetActive(true);
        }
    }

    public void SetStarRating(int rating)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < rating)
            {
                stars[i].sprite = selectedStarSprite;
            }
            else
            {
                stars[i].sprite = unselectedStarSprite;
            }
        }
    }
}
