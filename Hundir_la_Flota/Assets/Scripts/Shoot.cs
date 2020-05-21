using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    private GameObject selectedGridSquare;

    public GameObject myGrid;

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
                    gridSquare.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    gridSquare.GetComponent<Image>().color = Color.cyan;
                }
            }
        }
    }
}
