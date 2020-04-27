using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int cols = 0;
    public int rows = 0;
    public float every_square_offset = 0.0f;
    public GameObject grid_square;
    public Vector2 startPosition = new Vector2(0.0f, 0.0f);
    public float square_scale = 1.0f;


    private List<GameObject> grid_squares = new List<GameObject>();
    void Start()
    {
        if (grid_square.GetComponent<GridSquare>() == null)
            Debug.LogError("grid_square object need to have GridSquare script attached");
        CreateGrid();
    }


    void Update()
    {
    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquaresPosition();
    }

    private void SpawnGridSquares()
    {
        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < cols; c++)
            {
                grid_squares.Add(Instantiate(grid_square) as GameObject);
                grid_squares[grid_squares.Count - 1].transform.parent = this.transform;
                grid_squares[grid_squares.Count - 1].transform.localScale = new Vector3(square_scale, square_scale, square_scale);
            }
        }
    }

    private void SetSquaresPosition()
    {
        var squareRect = grid_squares[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + every_square_offset;
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + every_square_offset;

        int colNumber = 0;
        int rowNumber = 0;

        foreach (GameObject square in grid_squares)
        {
            if(colNumber + 1  > cols)
            {
                rowNumber++;
                colNumber = 0;
            }

            var pos_x_offset = offset.x * colNumber;
            var pos_y_offset = offset.y * rowNumber;
            square.GetComponent<RectTransform>().anchoredPosition = new Vector3(startPosition.x + pos_x_offset, startPosition.y - pos_y_offset);
            square.GetComponent<GridSquare>().setPosition(colNumber,rowNumber);
            square.GetComponent<GridSquare>().setValue(0);
            colNumber++;
        }
    }
}
