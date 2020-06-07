using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{

    public void closeApp()
    {
        Application.Quit();
    }

    public void keepPlaying()
    {
        this.gameObject.SetActive(false);
    }
}
