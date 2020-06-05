using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IA : MonoBehaviour
{

    private int col;
    private int row;
    private int p;
    private bool isSunken = false;
    private bool lastHaveBoat = false;
    private int[] firstPos = new int[2] { -1, -1 };
    private int[] secondPos = new int[2] { -1, -1 };
    private int[] thirdPos = new int[2] { -1, -1 };
    private int[] fourthPos = new int[2] { -1, -1 };
    private int[] fivethPos = new int[2] { -1, -1 };
    private bool boatTouched = false;
    private int impactNumber;

    private List<GameObject> grid;
    private List<GameObject> shootedGridsquares = new List<GameObject>();

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

    public void shoot()
    {

        grid = panel.GetComponent<ThirdGrid>().getGrid();


        if (!boatTouched)
        {
            do
            {
                col = Random.Range(0, 10);
                row = Random.Range(0, 10);

            } while (validCoordinates(col, row) == false);
        }
        else
        {
            //Tenemos que coger 1 casilla ARRIBA, 1 DERECHA, 1 IZQUIERDA, 1 ABAJO teniendo en cuenta los limites del Tablero y las casillas ya disparadas
            if((secondPos[0] == -1) && (secondPos[1] == -1))
            {
                int[] one = new int[2] { firstPos[0] - 1, firstPos[1] };
                int[] two = new int[2] { firstPos[0] + 1, firstPos[1] };
                int[] three = new int[2] { firstPos[0], firstPos[1] - 1 };
                int[] four = new int[2] { firstPos[0], firstPos[1] + 1 };

                List<int[]> coords = new List<int[]>() { one, two, three, four };
                List<int[]> finalCoords = new List<int[]>();

                foreach (int[] coord in coords)
                {
                    if (goodCoordinates(coord[0], coord[1]) && validCoordinates(coord[0], coord[1]))
                    {
                        finalCoords.Add(coord);
                    }
                }


                int n = Random.Range(0, finalCoords.Count);

                int[] selectedCoords = finalCoords[n];


                col = selectedCoords[0];
                row = selectedCoords[1];
            }
            else
            {
                if(firstPos[0] == secondPos[0])//El barco está colocado en vertical
                {
                    col = firstPos[0];
                    row = searchRow();
                }
                else //El barco esta colocado en horizontal
                {
                    row = firstPos[1];
                    col = searchCol();
                }
            }

        }


        foreach (GameObject gridSquare in grid)
        {
            if ((col == gridSquare.GetComponent<GridSquare>().getCol()) && (row == gridSquare.GetComponent<GridSquare>().getRow()))
            {
                shootedGridsquares.Add(gridSquare);
                if (gridSquare.GetComponent<GridSquare>().getBoat())
                {
                    boatTouched = true;
                    impactNumber++;
                    List<GameObject> boatList = new List<GameObject>();
                    int ind = gridSquare.GetComponent<GridSquare>().getBoatId();
                    if (impactNumber == 1)
                    {
                        firstPos[0] = gridSquare.GetComponent<GridSquare>().getCol();
                        firstPos[1] = gridSquare.GetComponent<GridSquare>().getRow();
                    }
                    if(impactNumber == 2)
                    {
                        secondPos[0] = gridSquare.GetComponent<GridSquare>().getCol();
                        secondPos[1] = gridSquare.GetComponent<GridSquare>().getRow();
                    }
                    if (impactNumber == 3)
                    {
                        thirdPos[0] = gridSquare.GetComponent<GridSquare>().getCol();
                        thirdPos[1] = gridSquare.GetComponent<GridSquare>().getRow();
                    }
                    if (impactNumber == 4)
                    {
                        fourthPos[0] = gridSquare.GetComponent<GridSquare>().getCol();
                        fourthPos[1] = gridSquare.GetComponent<GridSquare>().getRow();
                    }


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
                            boatTouched = false;
                            resetPositions();

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

        if (8 == panel.GetComponent<BoatsStateController>().getBoatsPC())
        {
            string msg = "Lo siento. ¡Has perdido!";
            popUpMessage.GetComponent<PopUpPanel>().setVisible(msg);
        }
        else
        {
            this.gameObject.GetComponent<CountDownTimer>().startCountDown();
        }
    }

    private bool validCoordinates(int cols, int rows)
    {
        if(shootedGridsquares.Count > 0)
        {
            foreach (GameObject gridSquare in shootedGridsquares)
            {
                if ((cols == gridSquare.GetComponent<GridSquare>().getCol()) && (rows == gridSquare.GetComponent<GridSquare>().getRow()))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool goodCoordinates(int col, int row)
    {
        if ((-1 < col) && (col < 10) && (row > -1) && (row < 10))
        {
            return true;
        }

        return false;
    }

    private void resetPositions()
    {
        impactNumber = 0;
        firstPos[0] = -1;
        firstPos[1] = -1;
        secondPos[0] = -1;
        secondPos[1] = -1;
        thirdPos[0] = -1;
        thirdPos[1] = -1;
        fourthPos[0] = -1;
        fourthPos[1] = -1;
        fivethPos[0] = -1;
        fivethPos[1] = -1;
    }

    private int searchCol()
    {
        if(fourthPos[0] != -1)
        {

            List<int> coordsList = new List<int>() { firstPos[0], secondPos[0], thirdPos[0] , fourthPos[0]};

            int[] one = new int[2] { getHigher(coordsList) + 1, firstPos[1] };
            int[] two = new int[2] { getLower(coordsList) - 1, secondPos[1] };

            col = getCol(one, two);

            return col;

        }
        else if(thirdPos[0] != -1)
        {
            List<int> coordsList = new List<int>() { firstPos[0], secondPos[0], thirdPos[0]};

            int[] one = new int[2] { getHigher(coordsList) + 1, firstPos[1] };
            int[] two = new int[2] { getLower(coordsList) - 1, secondPos[1] };

            col = getCol(one, two);

            return col;

        }
        else
        {
            if(firstPos[0] > secondPos[0])
            {
                int[] one = new int[2] { firstPos[0] + 1, firstPos[1] };
                int[] two = new int[2] { secondPos[0] - 1, secondPos[1] };

                col = getCol(one, two);

                return col;
            }
            else
            {
                int[] one = new int[2] { firstPos[0] - 1, firstPos[1] };
                int[] two = new int[2] { secondPos[0] + 1, secondPos[1] };

                col = getCol(one, two);

                return col;
            }
        }

    }

    private int searchRow()
    {
        if(fourthPos[1] != -1)
        {
            List<int> coordsList = new List<int>() { firstPos[1], secondPos[1], thirdPos[1] , fourthPos[1]};

            int[] one = new int[2] { firstPos[0], getHigher(coordsList) + 1 };
            int[] two = new int[2] { secondPos[0], getLower(coordsList) - 1 };

            row = getRow(one, two);

            return row;
        }
        else if(thirdPos[1] != -1)
        {
            List<int> coordsList = new List<int>() { firstPos[1], secondPos[1], thirdPos[1] };

            int[] one = new int[2] { firstPos[0], getHigher(coordsList) + 1};
            int[] two = new int[2] { secondPos[0], getLower(coordsList) - 1};

            row = getRow(one, two);

            return row;
        }
        else
        {
            if(firstPos[1] > secondPos[1])
            {
                int[] one = new int[2] { firstPos[0], firstPos[1] + 1};
                int[] two = new int[2] { secondPos[0], secondPos[1] - 1};

                row = getRow(one, two);

                return row;


            }
            else
            {
                int[] one = new int[2] { firstPos[0], firstPos[1] - 1};
                int[] two = new int[2] { secondPos[0], secondPos[1] + 1};

                row = getRow(one, two);

                return row;
            }
        }
    }

    private int getHigher(List<int> list)
    {
        return list.Max();
    }

    private int getLower(List<int> list)
    {
        return list.Min();
    }

    private int getRow(int[] one, int[] two)
    {
        List<int[]> coords = new List<int[]>() { one, two };
        List<int[]> finalCoords = new List<int[]>();

        foreach (int[] coord in coords)
        {
            if (goodCoordinates(coord[0], coord[1]) && validCoordinates(coord[0], coord[1]))
            {
                finalCoords.Add(coord);
            }
        }

        int n = Random.Range(0, finalCoords.Count);

        int[] selectedCoords = finalCoords[n];

        row = selectedCoords[1];

        return row;
    }

    private int getCol(int[] one, int[] two)
    {
        List<int[]> coords = new List<int[]>() { one, two };
        List<int[]> finalCoords = new List<int[]>();

        foreach (int[] coord in coords)
        {
            if (goodCoordinates(coord[0], coord[1]) && validCoordinates(coord[0], coord[1]))
            {
                finalCoords.Add(coord);
            }
        }

        int n = Random.Range(0, finalCoords.Count);

        int[] selectedCoords = finalCoords[n];

        col = selectedCoords[0];

        return col;
    }
}
