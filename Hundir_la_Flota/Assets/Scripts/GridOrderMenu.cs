using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOrderMenu : MonoBehaviour
{

    public GameObject modesMenuScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backMenu()
    {
        this.gameObject.SetActive(false);
        modesMenuScreen.SetActive(true);
    }
}
