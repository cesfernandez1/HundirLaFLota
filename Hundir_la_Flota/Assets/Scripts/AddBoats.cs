using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBoats : MonoBehaviour
{

    private Dropdown dropDownBoats;
    private Dropdown dropDownPositions;
    public GameObject myGrid;
    public GameObject gridSquare;

    private int cols;
    private int rows;
    private GameObject mySelectedGridSquare;
    private int orientation;
    private string boat;
    private int boatSize;
    private int nBoat = 0;
    private Color myColor;
    private int gridCols;
    private int gridRows;
    private GameObject isAdded;
    private Button myButton;
    private Button startButton;


    private List<GameObject> boatPlace;
    private List<GameObject> gridSquares;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartGameButton").GetComponent<Button>();
        startButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getGridDimmensions()
    {

        gridCols = myGrid.GetComponent<Grid>().getCol();
        gridRows = myGrid.GetComponent<Grid>().getRows();

    }

    public void getValues()
    {
        gridSquares = myGrid.GetComponent<Grid>().gridSquare();
        mySelectedGridSquare = GameObject.Find("SelectedGridSquare");

        orientation = getBoatOrientation();
        boat = getBoat();

        boatSize = getBoatSize(boat);

        cols = mySelectedGridSquare.GetComponent<prueba>().getCol();
        rows = mySelectedGridSquare.GetComponent<prueba>().getRow();

        isAdded = GameObject.Find("BoatAdded");
        isAdded.GetComponent<boatIsAdded>().setAdded(false);


        if (checkSpace(gridCols, gridRows, boatSize, cols, rows, orientation))
        {
            PlaceBoat(cols, rows, boatSize, orientation, myColor);
            isAdded.GetComponent<boatIsAdded>().setAdded(true);
        }
        else
        {
        }

        if (isAdded.GetComponent<boatIsAdded>().getAdded())
        {
            dropDownBoats.GetComponent<DropDownBoats>().getValue();
        }
        else
        {
            nBoat--;
        }

        if(nBoat == 8)
        {
            myButton = GameObject.Find("AddBoatButton").GetComponent<Button>();
            myButton.enabled = false;
            startButton.enabled = true;
        }



        Debug.Log("Has seleccionado la Columna:" + cols + " Fila: " + rows);

    }

    private void PlaceBoat(int c, int r, int tamaño, int orientacion, Color color)
    {

        Boat b = new Boat(tamaño,tamaño,boat,nBoat);
        foreach (GameObject gridSquare in boatPlace)
        {
            gridSquare.GetComponent<Image>().color = color;
            gridSquare.GetComponent<GridSquare>().setValue(tamaño);
            gridSquare.GetComponent<GridSquare>().setBoat();
            gridSquare.GetComponent<Button>().interactable = false;
            gridSquare.GetComponent<GridSquare>().addBoat(b);
            //gridSquare.AddComponent<Boat>();
            //gridSquare.GetComponent<Boat>().setName(boat);
            //gridSquare.GetComponent<Boat>().setSize(tamaño);
            //gridSquare.GetComponent<Boat>().setValue(tamaño);
            //gridSquare.GetComponent<Boat>().setID(nBoat);
            //gridSquare.GetComponent<GridSquare>().;
        }
    }

    private int getBoatOrientation()
    {
        //Si es 0 => Vertical ( aumentamos las columnas) ; Si es 1 => Horizontal (aumentamos las filas)
        dropDownPositions = GameObject.Find("Dropdown-BoatsPosition").GetComponent<Dropdown>();

        return dropDownPositions.value;
    }

    private string getBoat()
    {
        dropDownBoats = GameObject.Find("Dropdown-Boats").GetComponent<Dropdown>();
        return dropDownBoats.captionText.text;
    }

    private int getBoatSize(string name)
    {

        if (name.Equals("Lancha (1 casilla)"))
        {
            myColor = Color.red;
            nBoat++;
            return 1;
        }
        else if (name.Equals("Buque (2 casillas)"))
        {
            myColor = Color.magenta;
            nBoat++;
            return 2;
        }
        else if (name.Equals("Submarino (3 casillas)"))
        {
            myColor = Color.green;
            nBoat++;
            return 3;
        }
        else if (name.Equals("Portaaviones (5 casillas)"))
        {
            myColor = Color.blue;
            nBoat++;
            return 5;
        }

        return 0;
    }

    private bool checkSpace(int gridC, int gridR, int boatS, int c, int r, int o)
    {

        boatPlace = new List<GameObject>();

        if (o == 0)
        {
            int p = 0;
            if ((c + boatS) <= (gridC))
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if (((c == gridSquare.GetComponent<GridSquare>().getCol()) && (r == gridSquare.GetComponent<GridSquare>().getRow())) && (p != boatSize))
                    {
                        boatPlace.Add(gridSquare);
                        if (gridSquare.GetComponent<GridSquare>().getBoat())
                            return false;
                        c++;
                        p++;
                    }
                }
            }
            else
            {
                return false;
            }

        }
        else
        {
            int p = 0;
            if ((r + boatS) <= (gridR))
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if ((c == gridSquare.GetComponent<GridSquare>().getCol()) && (r == gridSquare.GetComponent<GridSquare>().getRow()) && (p != boatSize))
                    {
                        boatPlace.Add(gridSquare);
                        if (gridSquare.GetComponent<GridSquare>().getBoat())
                            return false;
                        r++;
                        p++;
                    }
                }
            }
            else
            {
                return false;
            }

        }

        foreach (GameObject gridSquare in boatPlace)
        {
            if (gridSquare.GetComponent<GridSquare>().getBoat())
            {
                return false;
            }
        }

        return true;
    }

}
