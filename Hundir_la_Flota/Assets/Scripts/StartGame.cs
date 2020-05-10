using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
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

    public void startGame()
    {
        this.gameObject.SetActive(false);
        gamePanel.SetActive(true);
        gamePanel.GetComponent<SecondGrid>().FillList(this.gameObject.GetComponent<Grid>().gridSquare());
    }
}
