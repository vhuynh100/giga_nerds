using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientToCamera : MonoBehaviour
{
    private Transform mainCam;
    public GameObject target;
    [SerializeField] float yOffset = 0.0911f;   
    [SerializeField] float xOffset = 0.0911f;
    [SerializeField] float zOffset = 0f;

    private void OnEnable()
    {
        mainCam = Camera.main.transform;
        Debug.Log("Main Cam = " + mainCam.name);
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCam);
        transform.RotateAround(transform.position, transform.up, 180f);

        Vector3 targetPosition = target.transform.position;
        transform.position = new Vector3(targetPosition.x + xOffset, targetPosition.y + yOffset, targetPosition.z + zOffset);
    }
}