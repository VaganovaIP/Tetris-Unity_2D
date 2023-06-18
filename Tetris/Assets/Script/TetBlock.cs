using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetBlock : MonoBehaviour
{
    public Vector3 rotationPoint; 
    private float previuosTime;
    public float fallTime = 0.9f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

    public static int score = 0;
    public bool over = false;

    void Start()
    {
        
        score = 0;
        Time.timeScale = 1;
    }

    public void AddScore() {
        GameController game = new GameController();
        game.AddScore();
    }

    void Update()
    {
        gameOver();
        if (over)
        {
            Time.timeScale = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (ValidMove()) {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(1, 0, 0);
            if (ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1), 90);
            if (ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }
        //
        if (Time.time - previuosTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime/10:fallTime)) {
            transform.position += new Vector3(0, -1, 0);
            if (ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddGrid();
                CheckForLines();
                this.enabled = false;
                FindObjectOfType<SpawnTetromino1>().NewTetronimo();
            }
            previuosTime = Time.time;
        }

    }

    void AddGrid() {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX, roundedY] = children;
        }
    }

    void CheckForLines() {
        for (int i = height-1; i >=0; i--) {
            if (HasLine(i)) {
                DeleteLine(i);
                RowDown(i);
                AddScore();

            }
         }
    }

    bool HasLine(int i) {
        for (int j = 0; j < width; j++) {
            if (grid[j, i] == null) {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
     {
            for (int k = i; k < height; k++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (grid[j, k] != null) {
                        grid[j, k - 1] = grid[j, k];
                        grid[j, k] = null;
                        grid[j, k - 1].transform.position -= new Vector3(0, 1, 0);
                    }
                }
            }
     }

    void gameOver()
    {
            for (int w = 0; w < width; w++)
            {
                if (grid[w, 12] != null) { 
                    over = true;
                }
            };
    }
    //допуск перемещения объектов
    bool ValidMove() {
        foreach (Transform children in transform) {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            if (roundedX < 0 || roundedX >= width || roundedY >= height || roundedY < 0) {
                return true;
            }
            if (grid[roundedX, roundedY] != null) return true;
        }
        return false;
    }
}
