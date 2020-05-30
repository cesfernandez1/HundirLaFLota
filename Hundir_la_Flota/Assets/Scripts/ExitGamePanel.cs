using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGamePanel : MonoBehaviour
{

    public GameObject modesMenuScreen;
    public GameObject gamePanel;
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
        gamePanel.SetActive(false);
        modesMenuScreen.SetActive(true);
        this.gameObject.GetComponent<SecondGrid>().deleteGrid();
        this.gameObject.GetComponent<ThirdGrid>().deleteGrid();
        this.gameObject.GetComponent<BoatsStateController>().deleteData();
        //Reiniciar TODO 
    }

    public void stayGame()
    {
        this.gameObject.SetActive(false);
    }
}
