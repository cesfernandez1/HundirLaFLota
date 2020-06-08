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
    public GameObject popUp;

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
    private List<GameObject> invalidGridSquaresList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartGameButton").GetComponent<Button>();
        startButton.enabled = false;
    }

    public void getGridDimmensions()
    {

        gridCols = myGrid.GetComponent<Grid>().getCol();
        gridRows = myGrid.GetComponent<Grid>().getRows();

    }

    public void getValues()
    {
        gridSquares = myGrid.GetComponent<Grid>().getGrid();
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
            invalidGridSquares(cols, rows, boatSize, orientation);
            isAdded.GetComponent<boatIsAdded>().setAdded(true);
        }
        else
        {
            showPopUpPanel();
        }

        if (isAdded.GetComponent<boatIsAdded>().getAdded())
        {
            dropDownBoats.GetComponent<DropDownBoats>().getValue(boat);
        }
        else
        {
            nBoat--;
        }

        if (nBoat == 8)
        {
            myButton = GameObject.Find("AddBoatButton").GetComponent<Button>();
            myButton.enabled = false;
            startButton.enabled = true;
        }

        dropDownBoats.GetComponent<DropDownBoats>().updateDropDown();

    }

    private void PlaceBoat(int c, int r, int tamaño, int orientacion, Color color)
    {

        Boat b = new Boat(tamaño, tamaño, boat, nBoat);
        foreach (GameObject gridSquare in boatPlace)
        {
            gridSquare.GetComponent<Image>().color = color;
            gridSquare.GetComponent<GridSquare>().setValue(tamaño);
            gridSquare.GetComponent<GridSquare>().setBoat();
            gridSquare.GetComponent<Button>().enabled = false;
            gridSquare.GetComponent<GridSquare>().addBoat(b);
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
                        if (!validCoordinates(c, r))
                            return false;
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
                        if (!validCoordinates(c, r))
                            return false;
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

    private void invalidGridSquares(int col, int row, int boatSize, int orien)
    {
        int p = 0;
        int c = col;
        int r = row;
        if (orien == 0)
        {
            if (row > 0)
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if ((c == gridSquare.GetComponent<GridSquare>().getCol()) && ((row - 1) == gridSquare.GetComponent<GridSquare>().getRow()) && (p != boatSize))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                        c++;
                        p++;
                    }
                }
            }
            if (row < 9)
            {
                p = 0;
                c = col;
                foreach (GameObject gridSquare in gridSquares)
                {
                    if ((c == gridSquare.GetComponent<GridSquare>().getCol()) && ((row + 1) == gridSquare.GetComponent<GridSquare>().getRow()) && (p != boatSize))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                        c++;
                        p++;
                    }
                }
            }
            if (col > 0)
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if (((col - 1) == gridSquare.GetComponent<GridSquare>().getCol()) && (row == gridSquare.GetComponent<GridSquare>().getRow()))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                    }
                }
            }
            if ((col + boatSize) < 9)
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if (((col + boatSize) == gridSquare.GetComponent<GridSquare>().getCol()) && (row == gridSquare.GetComponent<GridSquare>().getRow()))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                    }
                }
            }

        }
        else
        {
            p = 0;
            if (col > 0)
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if (((col - 1) == gridSquare.GetComponent<GridSquare>().getCol()) && (r == gridSquare.GetComponent<GridSquare>().getRow()) && (p != boatSize))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                        r++;
                        p++;
                    }
                }
            }
            if (col < 9)
            {
                p = 0;
                r = row;
                foreach (GameObject gridSquare in gridSquares)
                {
                    if (((col + 1) == gridSquare.GetComponent<GridSquare>().getCol()) && (r == gridSquare.GetComponent<GridSquare>().getRow()) && (p != boatSize))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                        r++;
                        p++;
                    }
                }
            }
            if (row > 0)
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if ((col == gridSquare.GetComponent<GridSquare>().getCol()) && ((row - 1) == gridSquare.GetComponent<GridSquare>().getRow()))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                    }
                }
            }
            if ((row + boatSize) < 9)
            {
                foreach (GameObject gridSquare in gridSquares)
                {
                    if ((col == gridSquare.GetComponent<GridSquare>().getCol()) && ((row + boatSize) == gridSquare.GetComponent<GridSquare>().getRow()))
                    {
                        invalidGridSquaresList.Add(gridSquare);
                    }
                }
            }
        }
    }

    private bool validCoordinates(int col, int row)
    {
        if (invalidGridSquaresList.Count > 0)
        {
            foreach (GameObject gridSquare in invalidGridSquaresList)
            {
                if ((col == gridSquare.GetComponent<GridSquare>().getCol()) && (row == gridSquare.GetComponent<GridSquare>().getRow()))
                    return false;
            }
        }
        return true;
    }

    private void showPopUpPanel()
    {
        popUp.SetActive(true);
    }

    public void removeData()
    {
        nBoat = 0;
        invalidGridSquaresList.Clear();
    }

}
