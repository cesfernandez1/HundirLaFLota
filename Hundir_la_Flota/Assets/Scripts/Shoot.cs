using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    private GameObject selectedGridSquare;

    public GameObject popUpMessage;

    public GameObject myGrid;

    public GameObject coverPanel;

    private int cols;
    private int rows;

    private List<GameObject> grid;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getValues()
    {
        selectedGridSquare = GameObject.Find("SelectedGridSquare");

        cols = selectedGridSquare.GetComponent<prueba>().getCol();
        rows = selectedGridSquare.GetComponent<prueba>().getRow();

        shoot(cols,rows);

        StartCoroutine(waiter());
    }

    private void shoot(int col, int row)
    {
        grid = myGrid.GetComponent<SecondGrid>().getGrid();

        foreach(GameObject gridSquare in grid)
        {
            if ((col == gridSquare.GetComponent<GridSquare>().getCol()) && (row == gridSquare.GetComponent<GridSquare>().getRow()))
            {
                if (gridSquare.GetComponent<GridSquare>().getBoat())
                {
                    List<GameObject> boatList = new List<GameObject>();
                    int ind = gridSquare.GetComponent<GridSquare>().getBoatId();

                    foreach(GameObject gridS in grid)
                    {
                        if (gridS.GetComponent<GridSquare>().getBoat())
                        {
                            if (ind == gridS.GetComponent<GridSquare>().getBoatId())
                            {
                                boatList.Add(gridS);
                            }
                        }
                    }

                    foreach(GameObject gridS in boatList)
                    {
                        gridS.GetComponent<GridSquare>().addImpact();
                    }

                    if (gridSquare.GetComponent<GridSquare>().isSunken())
                    {

                        foreach(GameObject gridS in boatList)
                        {
                            gridS.GetComponent<Image>().color = Color.red;
                            gridS.GetComponent<Button>().enabled = false;
                        }
                        myGrid.GetComponent<BoatsStateController>().addBoatSunken();
                    }
                    else
                    {
                        gridSquare.GetComponent<Image>().color = Color.yellow;
                        gridSquare.GetComponent<Button>().enabled = false;
                    }
                }
                else
                {
                    gridSquare.GetComponent<Image>().color = Color.cyan;
                    gridSquare.GetComponent<Button>().enabled = false;
                }
            }
        }

        if (8 == myGrid.GetComponent<BoatsStateController>().getBoats())
        {
            string msg = "¡Enhorabuena! Has ganado";
            popUpMessage.GetComponent<PopUpPanel>().setVisible(msg);
        }
    }

    IEnumerator waiter()
    {

        coverPanel.SetActive(true);
        yield return new WaitForSeconds(10);

        //add here the function that IA shoot

        myGrid.GetComponent<IA>().shoot();
    }
}
