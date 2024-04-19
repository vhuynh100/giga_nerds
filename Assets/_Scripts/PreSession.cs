using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//TODO:
// connect timer to Duration: XX:XX
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

    void Start()
    {
        Menu1.SetActive(true);
        Menu2.SetActive(false);
        EndMenu.SetActive(false);

    }

    void OnGoalSelected()
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
            Menu2.SetActive(true);
            Debug.Log("Goal selected: " + playerGoal);
            if (playerGoal == 1) { goalText.text = "Pronunciation"; }
            else if (playerGoal == 2) { goalText.text = "Vocabulary"; }
            else if (playerGoal == 3) { goalText.text = "Fluency"; }
            else if (playerGoal == 4) { goalText.text = "Grammar Accuracy"; }
            goalText.text += " goal completed!";
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


    // Update is called once per frame
    void Update()
    {

    }
}
