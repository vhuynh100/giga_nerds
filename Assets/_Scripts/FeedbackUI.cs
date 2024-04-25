using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackUI : MonoBehaviour
{
    //public ToggleGroup starToggleGroup;
    public TMP_Text goalText; //set with setGoal(string) function

    //star ratings
    private int finalStarRating = 0;
    public Image[] starImages;
    public Sprite YellowStar;
    public Sprite EmptyStar;

    //selected tags and colors
    public Color unselectedColor = new Color(1.0f, 0.7176471f, 0.01176471f);
    public Color selectedColor = new Color(0.1294118f, 0.6196079f, 0.7372549f);
    public Image[] tags;// used to change tag color
    bool pronunciationTag = false;
    bool vocabTag = false;
    bool articulationTag = false;
    List<string> selectedTags = new List<string>();
    private string selectedGoal;

    //feedback comment is located in this variable
    public TMP_Text feedbackText;
    public MyFeedbackManager manager;

    public void setGoal(string goal)
    {
        goalText.text = goal;
        selectedGoal = goal;
    }
    public void setStars(int selectedStar)
    {
        //Debug.Log(selectedStar);
        finalStarRating = selectedStar;
        for (int i = 0; i < starImages.Length; i++)
        {
            if (i < selectedStar)
            {
                starImages[i].sprite = YellowStar;
            }
            else
            {
                starImages[i].sprite = EmptyStar;
            }
        }
    }

    public void toggleTags(string tag)
    {
        switch (tag)
        {
            case "pronunciation":
                pronunciationTag = !pronunciationTag;
                ToggleTagColor(tags[0], pronunciationTag);
                break;
            case "vocabulary":
                vocabTag = !vocabTag;
                ToggleTagColor(tags[1], vocabTag);
                break;
            case "articulation":
                articulationTag = !articulationTag;
                ToggleTagColor(tags[2], articulationTag);
                break;
        }
    }

    private void ToggleTagColor(Image tagImage, bool isSelected)
    {
        tagImage.color = isSelected ? selectedColor : unselectedColor;
    }

    public void closeMenu()
    {
        if (pronunciationTag)
        {
            selectedTags.Add("Pronunciation");
        }

        if (vocabTag)
        {
            selectedTags.Add("Vocabulary");
        }

        if (articulationTag)
        {
            selectedTags.Add("Articulation");
        }

        FeedbackEntry entry = new FeedbackEntry(DateTime.Now, selectedTags, finalStarRating, selectedGoal, feedbackText.ToString());

        //send data to player's personal feedback menu
        manager.AddFeedbackEntry(entry);
    }
}
