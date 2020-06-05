using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeApp()
    {
        Application.Quit();
    }

    public void keepPlaying()
    {
        this.gameObject.SetActive(false);
    }
}
