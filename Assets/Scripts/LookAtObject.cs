using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] GameObject _object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _object.transform.position); //keeps the front of object facing camera even if item rotated
        //need a way to keep it hovered over the object without rotating when the item is rotated
    }
}
