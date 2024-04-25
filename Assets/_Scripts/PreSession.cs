using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEditor.PackageManager.Requests;
using UnityEngine.UIElements;

//TODO:
// connect session exit button to exitSession()


public class PreSession : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu1;
    public GameObject Menu2;
    public GameObject EndMenu;
    public GameObject selectGoalAlert;
    public GameObject interactableCanvas;
    public TMP_Text goalText;

    private bool goalSelected = false;
    private int playerGoal;

    public string _player1Goal = default;
    public string _player2Goal = default;
    public string _player1Feedback = default;
    public string _player2Feedback = default;

    private int playerNum = 0;

    private PlayerFeedback _playerFeedback;

    void Start()
    {
        //Menu1.SetActive(true);
        Menu2.SetActive(false);
        EndMenu.SetActive(false);
    }

    private void Awake()  // DO NOT SET _playerFeedback INITIAL VARIABLE VALUES IN THIS Awake! only set initial variable values in PlayerFeedback.cs
    {
        _playerFeedback = GetComponent<PlayerFeedback>();
    }

    public void OnGoalSelected()
    {
        goalSelected = true;
    }

    public void sessionGoal(int goalNum)
    {
        playerGoal = goalNum;
        goalSelected = true;
    }

    public bool isSelection()
    {
        return goalSelected;
    }

    public void nextMenu()
    {
        if (isSelection())
        {
            Menu1.SetActive(false);
            //Menu2.SetActive(true); TODO: Uncomment
            Debug.Log("Goal selected: " + playerGoal);
            if (playerGoal == 1)
            {
                //goalText.text = "Pronunciation";
                SetPlayerGoal("Pronunciation");
            }
            else if (playerGoal == 2)
            {
                //goalText.text = "Vocabulary";
                SetPlayerGoal("Vocabulary");
            }
            else if (playerGoal == 3)
            {
                //goalText.text = "Fluency";
                SetPlayerGoal("Fluency");
            }
            else if (playerGoal == 4)
            {
                //goalText.text = "Grammar Accuracy";
                SetPlayerGoal("Grammar Accuracy");
            }
            //goalText.text += " goal completed!";

            EndMenu.SetActive(true);
            if (playerNum == 1)
            {
                goalText.text = "Goal selected: " + _playerFeedback.GetPlayer2Goal();
            }
            else if (playerNum == 2)
            {
                goalText.text = "Goal selected: " + _playerFeedback.GetPlayer1Goal();
            }
        }
        else
        {
            Debug.Log("Goal not selected");
            selectGoalAlert.SetActive(true);
        }
    }

    public void joinRoom()
    {
        Menu2.SetActive(false);
        interactableCanvas.SetActive(false);
        // start timer for session duration
        // Insert scene change code here
    }

    public void exitSession()
    {
        // update session duration and words spoken
        EndMenu.SetActive(true);
        interactableCanvas.SetActive(true);
    }

    public void returnMenu()
    {
        EndMenu.SetActive(false);
        interactableCanvas.SetActive(false);
    }

    public void SetPlayerGoal(string goal)
    {
        if (playerNum == 0 & _playerFeedback.GetPlayer1Goal() == "")
        {
            playerNum = 1;
            _playerFeedback.SetPlayer1Goal(goal);
        }
        else if (playerNum == 0 & _playerFeedback.GetPlayer2Goal() == "")
        {
            playerNum = 2;
            _playerFeedback.SetPlayer2Goal(goal);
        }
    }

    void Update()
    {
        // TODO: Check if realtime player goals are empty and update UI when they're populated
    }
}
