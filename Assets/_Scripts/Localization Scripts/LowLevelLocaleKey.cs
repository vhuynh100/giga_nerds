using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowLevelLocaleKey : MonoBehaviour
{
    // Start is called before the first frame update
    private string tableName;

    public void SetHighLevelLocaleTableName(string name) {
        tableName = name;
        Debug.Log("Table Name is: " + tableName + ", Key Name is: " + gameObject.name);
    }

    public string GetHighLevelLocaleTableName() {
        return tableName;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
