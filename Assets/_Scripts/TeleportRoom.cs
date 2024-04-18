using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRoom : MonoBehaviour
{
    public GameObject TeleportUI;
    //public GameObject prevMenuUI;
    public void teleportKitchen()
    {
        Debug.Log("Teleport to kitchen");
    }

    public void teleportBathroom()
    {
        Debug.Log("Teleport to bathroom");
    }

    public void teleportRestaurant()
    {
        Debug.Log("Teleport to restaurant");
    }

    public void beckButton()
    {
        TeleportUI.SetActive(false);
        //prevMenuUI.SetActive(true);
    }
    
}
