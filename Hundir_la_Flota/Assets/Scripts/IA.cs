using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA : MonoBehaviour
{

    private int col;
    private int row;
    private int p;

    private List<GameObject> grid;

    public GameObject panel;
    public GameObject popUpMessage;

    public GameObject coverPanel;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void shoot()
    {
        grid = panel.GetComponent<ThirdGrid>().getGrid();

        do
        {
            col = Random.Range(0, 10);
            row = Random.Range(0, 10);

        } while (validCoordinates(col, row) == false);

        foreach(GameObject gridSquare in grid)
        {
            if((col == gridSquare.GetComponent<GridSquare>().getCol()) && (row == gridSquare.GetComponent<GridSquare>().getRow()))
            {
                if (gridSquare.GetComponent<GridSquare>().getBoat())
                {
                    List<GameObject> boatList = new List<GameObject>();
                    int ind = gridSquare.GetComponent<GridSquare>().getBoatId();

                    foreach (GameObject gridS in grid)
                    {
                        if (gridS.GetComponent<GridSquare>().getBoat())
                        {
                            if (ind == gridS.GetComponent<GridSquare>().getBoatId())
                            {
                                boatList.Add(gridS);
                            }
                        }
                    }

                    foreach (GameObject gridS in boatList)
                    {
                        gridS.GetComponent<GridSquare>().addImpact();
                    }

                    if (gridSquare.GetComponent<GridSquare>().isSunken())
                    {

                        foreach (GameObject gridS in boatList)
                        {
                            gridS.GetComponent<Image>().color = Color.red;
                        }
                        panel.GetComponent<BoatsStateController>().addBoatSunkenPC();
                    }
                    else
                    {
                        gridSquare.GetComponent<Image>().color = Color.yellow;
                    }
                }
                else
                {
                    gridSquare.GetComponent<Image>().color = Color.cyan;
                }
            }
        }

        coverPanel.SetActive(false);

        if (8 == panel.GetComponent<BoatsStateController>().getBoats())
        {
            string msg = "¡Lo siento! Has perdido";
            popUpMessage.GetComponent<PopUpPanel>().setVisible(msg);
        }
    }

    private bool validCoordinates(int cols, int rows)
    {
        foreach(GameObject gridSquare in grid)
        {
            if((cols == gridSquare.GetComponent<GridSquare>().getCol()) && (row == gridSquare.GetComponent<GridSquare>().getRow()))
            {
                if (gridSquare.GetComponent<GridSquare>().getShoot())
                    return false;
            }
        }
        return true;
    }
}
