using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    private float countTimer = 10f;

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
        StartCoroutine(startTimer());
    }


    IEnumerator startTimer()
    {
        countTimer = 10f;
        while (countTimer > -0.1f)
        {
            timer.text = countTimer.ToString("0.0");

            yield return new WaitForSeconds(0.1f);

            //countDownTimer--;
            countTimer -= 0.1f;
        }

        this.gameObject.GetComponent<Shoot>().shootIA();

    }

    public void stopCountDown()
    {
        StopCoroutine(startTimer());
    }
}
