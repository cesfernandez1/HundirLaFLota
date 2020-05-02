using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatIsAdded : MonoBehaviour
{

    private bool isAdded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getAdded()
    {
        return isAdded;
    }

    public void setAdded(bool t)
    {
        isAdded = t;
    }
}
