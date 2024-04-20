using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleMenuShutOff : MonoBehaviour
{

    [SerializeField] ButtonManager toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        toggle.GameObject().SetActive(false);
    }

    private void OnDisable()
    {
        toggle.GameObject().SetActive(true);
    }
}
