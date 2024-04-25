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
    public TMP_Text goalText;

    private bool goalSelected = false;
    private int playerGoal;

    public string _player1Goal = "";
    public string _player2Goal = "";
    private int playerNum = 0;
    public PlayerFeedback _playerFeedback;

    public GameObject PartnerFeedbackMenu;

    void Start()
    {
        Menu1.SetActive(true);
        Menu2.SetActive(false);
        EndMenu.SetActive(false);

        if (playerNum == 0 & _playerFeedback.GetPlayer1Goal() == "")
        {
            playerNum = 1;
        }
        else if (playerNum == 0 & _playerFeedback.GetPlayer2Goal() == "")
        {
            playerNum = 2;
        }

        Debug.Log("*** playernum:" + playerNum);
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
            if (playerGoal == 1) {
                //goalText.text = "Pronunciation";
                SetPlayerGoal("Pronunciation");
            }
            else if (playerGoal == 2) {
                //goalText.text = "Vocabulary";
                SetPlayerGoal("Vocabulary");
            }
            else if (playerGoal == 3) {
                //goalText.text = "Fluency";
                SetPlayerGoal("Fluency");
            }
            else if (playerGoal == 4) {
                //goalText.text = "Grammar Accuracy";
                SetPlayerGoal("Grammar Accuracy");
            }

            //EndMenu.SetActive(true);
            if (playerNum == 1)
            {
                goalText.text = _playerFeedback.GetPlayer2Goal();
            }
            else if (playerNum == 2)
            {
                goalText.text = _playerFeedback.GetPlayer1Goal();
            }

        }
        else
        {
            Debug.Log("Goal not selected");
            selectGoalAlert.SetActive(true);
        }

        Menu1.SetActive(false);
        PartnerFeedbackMenu.SetActive(true);
    }

    public void joinRoom()
    {
        Menu2.SetActive(false);
        // start timer for session duration
        // Insert scene change code here
    }

    public void exitSession()
    {
        // update session duration and words spoken
        EndMenu.SetActive(true);
    }

    public void returnMenu()
    {
        EndMenu.SetActive(false);
    }

    public void SetPlayerGoal(string goal)
    {
        if (playerNum == 1)
        {
            _playerFeedback.SetPlayer1Goal(goal);
            _player1Goal = goal;
            Debug.Log("*** set player 1 goal: " + _playerFeedback.GetPlayer1Goal());
        }
        else if (playerNum == 2)
        {
            _playerFeedback.SetPlayer2Goal(goal);
            _player2Goal = goal;
            Debug.Log("*** set player 2 goal: " + _playerFeedback.GetPlayer2Goal());
        }
    }

    void Update()
    {
        // TODO: Check if realtime player goals are empty and update UI when they're populated
        if (playerNum == 1)
        {
            if (_playerFeedback.GetPlayer2Goal() != _player2Goal)
            {
                _player2Goal = _playerFeedback.GetPlayer2Goal();
                goalText.text = _playerFeedback.GetPlayer2Goal();
                Debug.Log("*** player 2 goal:" + _playerFeedback.GetPlayer2Goal());
            }
        }
        else if (playerNum == 2)
        {
            if (_playerFeedback.GetPlayer1Goal() != _player1Goal)
            {
                _player1Goal = _playerFeedback.GetPlayer1Goal();
                goalText.text = _playerFeedback.GetPlayer1Goal();
                Debug.Log("*** player 1 goal:" + _playerFeedback.GetPlayer1Goal());
            }
        }
    }
}
