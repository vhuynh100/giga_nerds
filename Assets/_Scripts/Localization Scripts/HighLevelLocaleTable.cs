using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLevelLocaleTable : MonoBehaviour
{
    // Start is called before the first frame update
    private LowLevelLocaleKey lowLevelLocaleKeyScript;
    private void Start()
    {
        lowLevelLocaleKeyScript = GetComponentInChildren<LowLevelLocaleKey>();
        if(lowLevelLocaleKeyScript != null) {
            lowLevelLocaleKeyScript.SetHighLevelLocaleTableName(gameObject.name);
        }
        else {
            Debug.LogError("Low level key not found within High level object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
