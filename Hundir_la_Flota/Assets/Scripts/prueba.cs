using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prueba : MonoBehaviour
{

    private GridSquare gridSquare;
    private int cols;
    private int rows;
    private int value;
    private GameObject myObject;
    // Start is called before the first frame update
    void Start()
    {
        myObject = GameObject.Find("SelectedGridSquare");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void getGridSquare(GridSquare myGridSquare)
    {
        gridSquare = myGridSquare;
        cols = gridSquare.getCol();
        rows = gridSquare.getRow();
    }

    public int getCol()
    {
        return cols;
    }

    public int getRow()
    {
        return rows;
    }
}
