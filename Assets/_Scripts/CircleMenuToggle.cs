using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMenuToggle : MonoBehaviour
{
    public GameObject circleMenu;
    public OVRHand hand;
    public OVRSkeleton skeleton;

    void Start()
    {
        skeleton = GetComponentInChildren<OVRSkeleton>() ?? skeleton;

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

            if (wristBone.Transform.forward.y > 0.7f)
            {
                ActivateMenu();
            }
            else
            {
                DeactivateMenu();
            }
        }
    }

    private void ActivateMenu()
    {
        if (!circleMenu.activeSelf)
        {
            circleMenu.SetActive(true);
        }
    }

    private void DeactivateMenu()
    {
        if (circleMenu.activeSelf)
        {
            circleMenu.SetActive(false);
        }
    }
}
