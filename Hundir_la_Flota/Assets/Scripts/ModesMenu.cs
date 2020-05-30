using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModesMenu : MonoBehaviour
{
    public GameObject mainMenuScreen;
    public GameObject multiplayerMenuScreen;
    public GameObject gridOrderScreen;
    public GameObject dropD;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MultiplayerMenuScreen()
    {
        this.gameObject.SetActive(false);
        multiplayerMenuScreen.SetActive(true);
    }

    public void backMenu()
    {
        this.gameObject.SetActive(false);
        mainMenuScreen.SetActive(true);
    }

    public void GridOrderScreen()
    {
        this.gameObject.SetActive(false);
        gridOrderScreen.SetActive(true);
        gridOrderScreen.GetComponent<Grid>().CreateGrid();
        gridOrderScreen.GetComponent<GridPC>().CreateGrid();
        //gridOrderScreen.GetComponent<DropDownBoats>().FillBoatList();
        dropD.GetComponent<DropDownBoats>().FillBoatList();
    }
}
