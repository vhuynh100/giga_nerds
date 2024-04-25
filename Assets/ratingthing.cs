using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ratingthing : MonoBehaviour
{

    [SerializeField] private MinimumFeedback minimumFeedback;
    [SerializeField] private GameObject feedbackUI;
    [SerializeField] private Realtime realtime;
    [SerializeField] private TMP_Text ratingDisplayText;
    [SerializeField] private GameObject ratingDisplay;

    private bool didLobbyEnd = false;
    private int playerNum = 0;
    private int yourFeedback = 0;
    private bool sentPartnerFeedback = false;

    private int recievedFeedback = 0;

    void Update()
    {

        if (minimumFeedback.GetDidLobbyEnd() == true && playerNum == 0)
        {
            feedbackUI.SetActive(true);
            playerNum = 2;
        }

        if(playerNum == 1)
        {
            if (minimumFeedback.GetPlayer1Rating() != 0)
            {
                yourFeedback = minimumFeedback.GetPlayer1Rating();
            }
        } else if (playerNum == 2)
        {
            if (minimumFeedback.GetPlayer2Rating() != 0)
            {
                yourFeedback = minimumFeedback.GetPlayer2Rating();
            }
        }

        if (playerNum == 1)
        {
            if (minimumFeedback.GetPlayer1Rating() != 0)
            {
                yourFeedback = minimumFeedback.GetPlayer1Rating();
            }
        } else if (playerNum == 2)
        {
            if (minimumFeedback.GetPlayer2Rating() != 0)
            {
                yourFeedback = minimumFeedback.GetPlayer2Rating();
            }
        }

        if (minimumFeedback.GetDidLobbyEnd() == true && yourFeedback != 0 && sentPartnerFeedback == true)
        {
            feedbackUI.SetActive(false);
            BackToLobby();
        }


    }

    public void EndLobby()
    {
        minimumFeedback.SetDidLobbyEnd(true);
        feedbackUI.SetActive(true);
        if (playerNum == 0)
        {
            playerNum = 1;
        }
    }

    public void SetPartnerFeedback(int rating)
    {
        if(playerNum == 1)
        {
            minimumFeedback.SetPlayer2Rating(rating);
            if (minimumFeedback.GetPlayer2Rating() != 0)
            {
                sentPartnerFeedback = true;
            }
        }
        else if(playerNum == 2)
        {
            minimumFeedback.SetPlayer1Rating(rating);
            if (minimumFeedback.GetPlayer1Rating() != 0)
            {
                sentPartnerFeedback = true;
            }
        }
    }

    public void BackToLobby()
    {
        int wait = 0;

        while (wait > 100)
        {
            wait++;
        }

        realtime.Disconnect();
        realtime = null;
        realtime = FindObjectOfType<Realtime>();
        print("=== moving to lobby: ");
        realtime.Connect("0");
        ratingDisplayText.text = yourFeedback.ToString() + " Stars";
        ratingDisplay.SetActive(true);

    }
}
