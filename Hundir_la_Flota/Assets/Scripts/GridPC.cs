using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using UnityEngine.UI;

public class GridPC : MonoBehaviour
{
    public GameObject grid_square;
    private int gridCols = 10;
    private int gridRows = 10;
    private string boat;
    private int nBoat = 0;
    private int boatsAdded = 0;
    private Color myColor;

    Boat[] pcBoat = new Boat[8];
    private List<GameObject> grid_squaresPC;
    private List<GameObject> boatPlace;
    private List<string> boats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        if (grid_square.GetComponent<GridSquare>() == null)
            Debug.LogError("grid_square object need to have GridSquare script attached");
        CreateGrid();
    }

    public void CreateGrid()
    {
        grid_squaresPC = new List<GameObject>();
        AddGridSquares();
        boats = new List<string>() { "Lancha", "Lancha", "Lancha", "Buque", "Buque", "Submarino", "Submarino", "Portaaviones" };

        do
        {
            AddBoats();

        } while (boatsAdded < 8);
    }

    private void AddGridSquares()
    {
        for(int r=0; r < gridRows; r++)
        {
            for(int c=0; c < gridCols; c++)
            {
                grid_squaresPC.Add(Instantiate(grid_square) as GameObject);
            }
        }

        int colNumber = 0;
        int rowNumber = 0;

        foreach (GameObject square in grid_squaresPC)
        {
            if (colNumber + 1 > gridCols)
            {
                rowNumber++;
                colNumber = 0;
            }

            square.GetComponent<GridSquare>().setPosition(colNumber, rowNumber);
            square.GetComponent<GridSquare>().setValue(0);
            colNumber++;
        }

    }

    private void AddBoats()
    {

        int cols = -1;
        int rows = -1;
        int orientation = -1;
        int selectedBoat = Random.Range(0, boats.Count);
        boat = boats[selectedBoat];


        int boatSize = getBoatSize(boat);

        cols = Random.Range(0,10);
        rows = Random.Range(0,10);
        orientation = Random.Range(0,2); //Si es 0 => Horizontal ; Si es 1 => Vertical

        if (checkSpace(cols,rows,orientation,boatSize,gridCols,gridRows))
        {
            Placeboat(cols,rows,boatSize,orientation,myColor);
            boats.Remove(boat);
            boatsAdded++;
        }

    }

    public List<GameObject> getGrid()
    {
        return grid_squaresPC;
    }

    private void Placeboat(int columns, int rows, int tamaño, int orientacion, Color color)
    {
        Boat b = new Boat(tamaño, tamaño, boat, nBoat);

        foreach(GameObject gridSquare in boatPlace)
        {
            gridSquare.GetComponent<Image>().color = color;
            gridSquare.GetComponent<GridSquare>().setValue(tamaño);
            gridSquare.GetComponent<GridSquare>().setBoat();
            gridSquare.GetComponent<GridSquare>().addBoat(b);
        }

        nBoat++;
    }

    private bool checkSpace(int columns, int rows, int orientation, int boatSize, int gridCols, int gridrows)
    {

        boatPlace = new List<GameObject>();

        if(orientation == 0)
        {
            int p = 0;
            if((columns + boatSize) <= gridCols)
            {
                foreach(GameObject gridSquare in grid_squaresPC)
                {
                    if(((columns == gridSquare.GetComponent<GridSquare>().getCol()) && (rows == gridSquare.GetComponent<GridSquare>().getRow())) && (p != boatSize))
                    {
                        boatPlace.Add(gridSquare);
                        if (gridSquare.GetComponent<GridSquare>().getBoat())
                            return false;
                        columns++;
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
            if((rows + boatSize) <= (gridrows))
            {
                foreach(GameObject gridSquare in grid_squaresPC)
                {
                    if((columns == gridSquare.GetComponent<GridSquare>().getCol()) && (rows == gridSquare.GetComponent<GridSquare>().getRow()) && (p != boatSize))
                    {
                        boatPlace.Add(gridSquare);
                        if (gridSquare.GetComponent<GridSquare>().getBoat())
                            return false;
                        rows++;
                        p++;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        foreach(GameObject gridSquare in boatPlace)
        {
            if (gridSquare.GetComponent<GridSquare>().getBoat())
                return false;
        }
        return true;
    }

    private int getBoatSize(string boat)
    {

        if (boat.Equals("Lancha"))
        {
            myColor = Color.red;
            return 1;
        }
        else if (boat.Equals("Buque"))
        {
            myColor = Color.magenta;
            return 2;
        }
        else if (boat.Equals("Submarino"))
        {
            myColor = Color.green;
            return 3;
        }
        else if (boat.Equals("Portaaviones"))
        {
            myColor = Color.blue;
            return 5;
        }
        return 0;
    }

    public void deleteGrid()
    {
        grid_squaresPC.Clear();
    }
}
