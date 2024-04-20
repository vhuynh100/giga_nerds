using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMenuToggle : MonoBehaviour
{
    public GameObject button;
    public GameObject circleMenu;
    public OVRHand hand;
    public OVRSkeleton skeleton;

    private bool isWristCheckedPreviously = false;

    void Start()
    {
        skeleton = GetComponentInChildren<OVRSkeleton>() ?? skeleton;

        if (button != null)
        {
            button.SetActive(false);
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
            bool checkingWrist = wristBone.Transform.forward.y > 0.7f;

            if (checkingWrist && !isWristCheckedPreviously)
            {
                button.SetActive(!button.activeSelf);
                isWristCheckedPreviously = true;
            }
            else if (!checkingWrist && isWristCheckedPreviously)
            {
                isWristCheckedPreviously = false;
            }
        }
    }

    public void ToggleMenu()
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
