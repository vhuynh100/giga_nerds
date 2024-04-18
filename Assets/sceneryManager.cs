using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneryManager : MonoBehaviour
{
    [SerializeField] GameObject lobbyScenery;
    [SerializeField] GameObject scenery1;
    [SerializeField] GameObject scenery2;
    [SerializeField] GameObject scenery3;
    [SerializeField] GameObject scenery4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableScene1()
    {
        scenery1.SetActive(true);
    }
}
