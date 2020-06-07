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
    private Button addBoats;
    private Button startGame;

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
        addBoats = GameObject.Find("AddBoatButton").GetComponent<Button>();
        addBoats.enabled = true;
        startGame = GameObject.Find("StartGameButton").GetComponent<Button>();
        startGame.enabled = false;
        gridOrderScreen.GetComponent<Grid>().CreateGrid();
        gridOrderScreen.GetComponent<GridPC>().CreateGrid();
        dropD.GetComponent<DropDownBoats>().FillBoatList();
    }
}
