using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMenuToggle : MonoBehaviour
{
    public GameObject circleMenuToggleButton;
    public GameObject circleMenu;
    public OVRHand hand;
    public OVRSkeleton skeleton;

    void Start()
    {
        skeleton = GetComponentInChildren<OVRSkeleton>() ?? skeleton;

        if (circleMenuToggleButton != null)
        {
            circleMenuToggleButton.SetActive(false);
        }

        if (circleMenu != null)
        {
            circleMenu.SetActive(false);
        }
    }

    void Update()
    {
        if (hand.IsTracked && skeleton != null)
        {
            OVRBone wristBone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_WristRoot];

            if (wristBone.Transform.forward.y > 0.5f)
            {
                ActivateButton();
            }
            else
            {
                DeactivateButton();
            }
        }
    }

    public void ActivateButton()
    {
        if (!circleMenuToggleButton.activeSelf)
        {
            circleMenuToggleButton.SetActive(true);
        }
    }

    public void DeactivateButton()
    {
        if (circleMenuToggleButton.activeSelf)
        {
            circleMenuToggleButton.SetActive(false);
        }
    }

    public void toggleMenu()
    {
        if (!circleMenu.activeSelf)
        {
            circleMenu.SetActive(true);
        }
        else
        {
            circleMenu.SetActive(false);
        }
    }
}
