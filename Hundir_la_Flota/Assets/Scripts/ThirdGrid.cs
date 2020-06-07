using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdGrid : MonoBehaviour
{
    private List<GameObject> grid;
    public float square_scale = 1.0f;
    public Vector2 startPosition = new Vector2(0.0f, 0.0f);
    public float every_square_offset = 0.0f;

    public void FillList(List<GameObject> list)
    {
        grid = list;

    }

    public void CreateGrid()
    {
        SpawnGridSquares();
        SetSquaresPosition();
    }

    private void SpawnGridSquares()
    {
        int n = 100;
        foreach (GameObject gridSquare in grid)
        {
            grid[grid.Count - n].transform.parent = this.transform;
            grid[grid.Count - n].transform.localScale = new Vector3(square_scale, square_scale, square_scale);
            n--;
        }


    }

    private void SetSquaresPosition()
    {
        var squareRect = grid[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + every_square_offset;
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + every_square_offset;

        int colNumber = 0;
        int rowNumber = 0;

        foreach (GameObject square in grid)
        {
            if (colNumber + 1 > 10)
            {
                rowNumber++;
                colNumber = 0;
            }

            var pos_x_offset = offset.x * colNumber;
            var pos_y_offset = offset.y * rowNumber;
            square.GetComponent<RectTransform>().anchoredPosition = new Vector3(startPosition.x + pos_x_offset, startPosition.y - pos_y_offset);
            square.GetComponent<Button>().interactable = true;
            square.GetComponent<Image>().color = Color.white;
            square.GetComponent<Button>().enabled = false;
            colNumber++;
        }
    }

    public List<GameObject> getGrid()
    {
        return grid;
    }

    public void deleteGrid()
    {
        grid.Clear();
    }
}
