using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PreSession : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu1;
    public GameObject Menu2;
    public GameObject selectGoalAlert;

    private bool goalSelected = false;
    private int playerGoal;

    void Start()
    {
        Menu1.SetActive(true);
        Menu2.SetActive(false);

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
        }
        else
        {
            Debug.Log("Goal not selected");
            selectGoalAlert.SetActive(true);
            // You can display a message to the user indicating they need to select an option before continuing
        }
    }

    public void joinRoom()
    {
        Menu2.SetActive(false);

        // Insert scene change code here
    }

    // Update is called once per frame
    void Update()
    {
    }
}
