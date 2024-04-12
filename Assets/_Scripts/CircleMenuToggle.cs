using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMenuToggle : MonoBehaviour
{
    [SerializeField] private GameObject circleMenu;
    [SerializeField] private OVRHand myHand;
    private bool isMenuVisible = true;

    void Start()
    {
        if (circleMenu != null)
        {
            circleMenu.SetActive(false);
            isMenuVisible = false;
        }
    }

    void Update()
    {
        CheckForPinch();
    }

    void CheckForPinch()
    {
        float pinchStrength = myHand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        if (pinchStrength > 0.7f && !isMenuVisible)
        {
            circleMenu.SetActive(true);
            isMenuVisible = true;
        }
        else if (pinchStrength < 0.7f && isMenuVisible)
        {
            circleMenu.SetActive(false);
            isMenuVisible = false;
        }
    }

}
