using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    private int col;
    private int row;
    private int value;
    private GameObject gridSquare;
    private bool boatAttached = false;
    private Boat boat;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setPosition(int c, int r)
    {
        col = c;
        row = r;
    }

    public void setValue(int v)
    {
        value = v;
    }

    public void setBoat()
    {
        boatAttached = true;
    }

    public int getCol()
    {
        return col;
    }

    public int getRow()
    {
        return row;
    }

    public int getValue()
    {
        return value;
    }

    public bool getBoat()
    {
        return boatAttached;
    }

    public void DrawPosition()
    {
        //if(this.GetComponent<Boat>() != null)
        //{
        //    Debug.Log("Nombre Embarcacion : " + this.GetComponent<Boat>().getName());
        //}
        //Debug.Log("Has presionado la celda COL: " + (col) + " ROW: " + (row) + " Valor: " + value + "" + this.GetComponent<Boat>().getName());
    }

    public void saveGridSquare()
    {
        gridSquare = GameObject.Find("SelectedGridSquare");
        gridSquare.GetComponent<prueba>().getGridSquare(this);
    }

    public void addBoat(Boat b)
    {
        boat = b;
    }


}
