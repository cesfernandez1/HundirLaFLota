using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    private int col;
    private int row;
    private int value;

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

    public int getCol()
    {
        return col;
    }

    public int getRow()
    {
        return row;
    }

    public void DrawPosition()
    {
        Debug.Log("Has presionado la celda COL:" + (col+1) + " ROW:" + (row+1));
    }


}
