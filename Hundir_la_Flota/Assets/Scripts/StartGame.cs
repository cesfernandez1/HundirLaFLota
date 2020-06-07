using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject gamePanel;
    public GameObject timerPanel;
    public GameObject starGamePanel;

    public void startGame()
    {
        this.gameObject.SetActive(false);
        timerPanel.SetActive(true);
        gamePanel.SetActive(true);
        starGamePanel.GetComponent<CountDownStart>().startGame();
        gamePanel.GetComponent<BoatsStateController>().startBoatsCounter();
        gamePanel.GetComponent<SecondGrid>().FillList(this.gameObject.GetComponent<GridPC>().getGrid());
        gamePanel.GetComponent<ThirdGrid>().FillList(this.gameObject.GetComponent<Grid>().getGrid());
        gamePanel.GetComponent<SecondGrid>().CreateGrid();
        gamePanel.GetComponent<ThirdGrid>().CreateGrid();
    }
}
