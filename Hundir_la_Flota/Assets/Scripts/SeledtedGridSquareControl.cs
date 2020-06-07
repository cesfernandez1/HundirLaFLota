using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeledtedGridSquareControl : MonoBehaviour
{
    public GameObject gamePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void accept()
    {
        this.gameObject.SetActive(false);
        gamePanel.GetComponent<CountDownTimer>().resumeTimer();
    }
}
