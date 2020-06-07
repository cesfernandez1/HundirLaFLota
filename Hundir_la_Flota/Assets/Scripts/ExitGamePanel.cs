using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGamePanel : MonoBehaviour
{

    public GameObject modesMenuScreen;
    public GameObject gamePanel;
    public GameObject gridorderScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame()
    {
        this.gameObject.SetActive(false);
        gridorderScreen.GetComponent<AddBoats>().removeData();
        gridorderScreen.GetComponent<Grid>().deleteGrid();
        gridorderScreen.GetComponent<GridPC>().deleteGrid();
        gamePanel.GetComponent<SecondGrid>().deleteGrid();
        gamePanel.GetComponent<ThirdGrid>().deleteGrid();
        gamePanel.GetComponent<BoatsStateController>().deleteData();
        gamePanel.GetComponent<CountDownTimer>().stopCountDown();
        gamePanel.SetActive(false);
        modesMenuScreen.SetActive(true);
        //Reiniciar TODO 
    }

    public void stayGame()
    {
        this.gameObject.SetActive(false);
        gamePanel.GetComponent<CountDownTimer>().resumeTimer();
    }
}
