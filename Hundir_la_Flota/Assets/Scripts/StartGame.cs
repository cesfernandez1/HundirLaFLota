using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject gamePanel;
    public GameObject timerPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        this.gameObject.SetActive(false);
        timerPanel.SetActive(true);
        gamePanel.SetActive(true);
        //gamePanel.GetComponent<SecondGrid>().FillList(this.gameObject.GetComponent<Grid>().gridSquare());
        gamePanel.GetComponent<SecondGrid>().FillList(this.gameObject.GetComponent<GridPC>().getGrid());
        gamePanel.GetComponent<ThirdGrid>().FillList(this.gameObject.GetComponent<Grid>().getGrid());  
    }
}
