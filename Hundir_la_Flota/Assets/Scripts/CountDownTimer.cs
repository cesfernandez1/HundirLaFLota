using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    private float countTimer = 10f;
    private bool timerRun = false;
    private bool iaShoot = false;

    public GameObject coverPanel;

    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startCountDown()
    {
        countTimer = 10f;
        timerRun = true;
        iaShoot = true;
        StartCoroutine(startTimer());
    }


    IEnumerator startTimer()
    {
        //countTimer = 10f;
        while (countTimer > -0.1f && timerRun)
        {
            timer.text = countTimer.ToString("0.0");

            yield return new WaitForSeconds(0.1f);

            //countDownTimer--;
            countTimer -= 0.1f;
        }

        if(iaShoot)
        {
            timer.text = "";
            this.gameObject.GetComponent<Shoot>().shootIA();
        }
    }

    public void pauseTimer()
    {
        iaShoot = false;
        timerRun = false;
    }

    public void resumeTimer()
    {
        iaShoot = true;
        timerRun = true;
        StartCoroutine(startTimer());
    }

    public void stopCountDown()
    {
        StopCoroutine(startTimer());
        iaShoot = false;

        timerRun = false;

        timer.text = "";
    }
}
