using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.SceneManagement;
public class TeleportRoom : MonoBehaviour
{
    public GameObject TeleportUI;
    //public GameObject prevMenuUI;
    public Button restaurantButton;
    public Button kitchenButton;
    public Button gymButton;

    public GameObject Restaurant;
    public GameObject Kitchen;
    public GameObject Gym;

    public GameObject Lobby;
    public GameObject Room;

    private string _previousSceneryName = "lobby";

    private SceneryChanger _sceneryChanger;

    private void Start()
    {
        restaurantButton.onClick.AddListener(() => setRestaurantActive());
        kitchenButton.onClick.AddListener(() => setKitchenActive());
        gymButton.onClick.AddListener(() => setGymActive());
    }
    private void Awake()  // DO NOT SET _requestSync INITIAL VARIABLE VALUES IN THIS Awake! only set initial variable values in RequestSync.cs
    {
        _sceneryChanger = GetComponent<SceneryChanger>();
    }

    private void Update()
    {
        if (_sceneryChanger.GetSceneryName() != _previousSceneryName)
        {
            if (_sceneryChanger.GetSceneryName() == "restaurant")
            {
                _previousSceneryName = "restaurant";
                setRestaurantActive();
            }
            else if (_sceneryChanger.GetSceneryName() == "kitchen")
            {
                _previousSceneryName = "kitchen";
                setKitchenActive();
            }
            else if (_sceneryChanger.GetSceneryName() == "gym")
            {
                _previousSceneryName = "gym";
                setGymActive();
            }
            else if (_sceneryChanger.GetSceneryName() == "lobby")
            {
                _previousSceneryName = "lobby";
            }



        }
    }


    public void setRestaurantActive()
    {
        _sceneryChanger.SetSceneryName("restaurant");
        Restaurant.SetActive(true);


        Room.SetActive(false);
        Lobby.SetActive(false);
        Kitchen.SetActive(false);
        Gym.SetActive(false);
        //Debug.Log("Set restaurant active");
    }

    public void setKitchenActive()
    {
        _sceneryChanger.SetSceneryName("kitchen");
        Kitchen.SetActive(true);
        Room.SetActive(false);
        Lobby.SetActive(false);
        Restaurant.SetActive(false);
        Gym.SetActive(false);
        //Debug.Log("Set kitchen active");
    }

    public void setGymActive()
    {
        _sceneryChanger.SetSceneryName("gym");
        Gym.SetActive(true);
        Room.SetActive(false);
        Lobby.SetActive(false);
        Kitchen.SetActive(false);
        Restaurant.SetActive(false);
        //Debug.Log("Set gym active");
    }

    public void backButton()
    {

        _sceneryChanger.SetSceneryName("lobby");
        Lobby.SetActive(true);
        Gym.SetActive(false);
        Room.SetActive(false);
        Kitchen.SetActive(false);
        Restaurant.SetActive(false);

        //TeleportUI.SetActive(false);
        //prevMenuUI.SetActive(true);
    }

}
