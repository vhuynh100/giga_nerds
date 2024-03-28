using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swag : MonoBehaviour
{
    NormalSceneLoader normalSceneLoader = new NormalSceneLoader();
   
    public int poggers = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        poggers++;
        print(poggers);

        if (poggers == 350)
        {
            normalSceneLoader.LoadScene();

        }
    }
}
