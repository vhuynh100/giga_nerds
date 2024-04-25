using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackUI : MonoBehaviour
{
    //public ToggleGroup starToggleGroup;
    public TMP_Text goalText; //set with setGoal(string) function

    //star ratings
    private int finalStarRating=0;
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

    //feedback comment is located in this variable
    public TMP_Text feedbackText;


    public void setGoal(string goal)
    {
        goalText.text = goal;
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
        //function here to send data somewhere
        Debug.Log(finalStarRating);
        Debug.Log(pronunciationTag ? "Pronunciation: True" : "Pronunciation: False");
        Debug.Log(vocabTag ? "Vocabulary: True" : "Vocabulary: False");
        Debug.Log(articulationTag ? "Articulation: True" : "Articulation: False");
        Debug.Log("Feedback Sent: " + feedbackText.text);

    }
}
