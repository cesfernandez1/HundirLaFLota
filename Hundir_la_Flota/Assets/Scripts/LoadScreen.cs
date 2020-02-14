using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{

    public Slider mySlider;
    public GameObject loadScreen;
    public GameObject mainMenuScreen;
    // Start is called before the first frame update
    void Start()
    {
        while (mySlider.value != 1)
        {
            mySlider.value += 0.000001f;
            UnityEngine.Debug.Log(mySlider.value);
        }

        if(mySlider.value == 1)
        {
            loadScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
