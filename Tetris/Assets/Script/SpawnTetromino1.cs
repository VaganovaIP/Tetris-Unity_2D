using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetromino1 : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    int history;

    // Start is called before the first frame update
    void Start()
    {
        NewTetronimo();
    }

    public void NewTetronimo()
    {
        int num_tetr;
        num_tetr = Random.Range(0, Tetrominoes.Length);
        if (num_tetr == history) {
            num_tetr = Random.Range(0, Tetrominoes.Length);
        }
        history = num_tetr;
        Instantiate(Tetrominoes[num_tetr], transform.position, Quaternion.identity);
    }
}
