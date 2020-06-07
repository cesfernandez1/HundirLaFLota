using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpPanel : MonoBehaviour
{

    public GameObject gamePanel;
    public GameObject menuPanel;
    public GameObject gridorderScreen;

    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVisible(string msg)
    {
        this.gameObject.SetActive(true);
        message.text = msg;
    }

    public void getBackOnMenu()
    {
        this.gameObject.SetActive(false);
        gamePanel.GetComponent<SecondGrid>().deleteGrid();
        gamePanel.GetComponent<ThirdGrid>().deleteGrid();
        gamePanel.GetComponent<BoatsStateController>().deleteData();
        gamePanel.GetComponent<CountDownTimer>().stopCountDown();
        gridorderScreen.GetComponent<AddBoats>().removeData();
        gridorderScreen.GetComponent<Grid>().deleteGrid();
        gridorderScreen.GetComponent<GridPC>().deleteGrid();
        gamePanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
