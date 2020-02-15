using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class LoadScreen : MonoBehaviour
{
    public GameObject bar;
    public int time;
    public GameObject mainMenuScreen;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time).setOnComplete(nextScreen);
    }

    public void nextScreen()
    {
        this.gameObject.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
