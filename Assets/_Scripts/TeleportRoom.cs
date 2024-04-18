using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        restaurantButton.onClick.AddListener(() => setRestaurantActive());
        kitchenButton.onClick.AddListener(() => setKitchenActive());
        gymButton.onClick.AddListener(() => setGymActive());

        Kitchen.SetActive(true);
    }

    public void setRestaurantActive()
    {
        Restaurant.SetActive(true);

        Kitchen.SetActive(false);
        Gym.SetActive(false);
        //Debug.Log("Set restaurant active");
    }

    public void setKitchenActive()
    {
        Kitchen.SetActive(true);

        Restaurant.SetActive(false);
        Gym.SetActive(false);
        //Debug.Log("Set kitchen active");
    }

    public void setGymActive()
    {
        Gym.SetActive(true);

        Kitchen.SetActive(false);
        Restaurant.SetActive(false);
        //Debug.Log("Set gym active");
    }

    public void backButton()
    {
        TeleportUI.SetActive(false);
        //prevMenuUI.SetActive(true);
    }
    
}
