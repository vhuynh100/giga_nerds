using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristButtonPositioner : MonoBehaviour
{
    public GameObject button;
    public OVRSkeleton skeleton;
    private Transform mainCam;
    public float hoverHeight = 0.1f;

    void Start()
    {
        skeleton = GetComponentInChildren<OVRSkeleton>() ?? skeleton;
        mainCam = Camera.main.transform;
    }

    void Update()
    {
        if (skeleton.IsInitialized)
        {
            OVRBone wristBone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_WristRoot];
            Vector3 wristPosition = wristBone.Transform.position;

            // Position the button above the wrist
            button.transform.position = new Vector3(wristPosition.x, wristPosition.y + hoverHeight, wristPosition.z);

            // Make the button face the user
            button.transform.LookAt(mainCam);
            button.transform.RotateAround(button.transform.position, button.transform.up, 180f);
        }
    }
}
