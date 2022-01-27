using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    public int height = 10;
    public int width = 10;

    public float GridSpaceSize = 1f;

    [SerializeField] private GameObject[] gridCellPrefab;
    [SerializeField] private GameObject   moveCubePrefab;
    
    private GameObject[,] gameGrid;
    private GameObject moveCube;
    // Start is called before the first frame update
    void Start()
    {
        gameGrid = new GameObject[width+2, height+2];
        CreateGrid();
    }

    void CreateGrid()
    {
        if (gridCellPrefab == null)
        {
            Debug.LogError("ERROR");
            return;
        }
        
        for (int y = 0; y < height + 2; y++)
        {
            for (int x = 0; x < width + 2; x++)
            {
                var yy = 0;
                if (x == 0 || x == width + 1 || y == 0 || y == height + 1)
                {
                    yy = 1;
                }
                var index = (x + y) % 2;
                if (x == 7 && y == 3)
                {
                    index = 2;
                }
                gameGrid[x, y] = Instantiate(gridCellPrefab[index], new Vector3(x * GridSpaceSize, yy, y * GridSpaceSize),
                    Quaternion.identity);
                gameGrid[x, y].transform.parent = transform;
                gameGrid[x, y].gameObject.name = "Grid Space ( X: " + x.ToString() + " , Z: " + y.ToString() + " )";
            }
        }

        moveCube = Instantiate(moveCubePrefab, new Vector3(5f * GridSpaceSize, 1, 5f * GridSpaceSize),
            Quaternion.identity);
        moveCube.transform.parent = transform;
        moveCube.gameObject.name = "MoveCube";

    }


}
