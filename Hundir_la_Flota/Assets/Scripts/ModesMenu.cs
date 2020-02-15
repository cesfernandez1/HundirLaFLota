using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModesMenu : MonoBehaviour
{
    public GameObject mainMenuScreen;
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
        mainMenuScreen.SetActive(true);
    }
}
