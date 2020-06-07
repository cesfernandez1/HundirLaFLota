using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownStart : MonoBehaviour
{
    private int countDownTimer = 3;

    public GameObject gamePanel;


    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startGame()
    {
        countDownTimer = 3;
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        while(countDownTimer > 0)
        {
            timer.text = countDownTimer.ToString();

            yield return new WaitForSeconds(1f);

            countDownTimer--;
        }


        timer.text = "¡VAMOS!";

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
        gamePanel.GetComponent<CountDownTimer>().startCountDown();
    }
}
