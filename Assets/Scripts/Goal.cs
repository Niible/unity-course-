using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameObject winText;
    private GameObject cube;
    private bool win = false;
    void Start()
    {
        cube = GameObject.FindWithTag("Movable");
        winText = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (win) return;
        if (transform.position.x == cube.transform.position.x && transform.position.z == cube.transform.position.z )
        {
            win = true;
            winText.transform.GetChild(2).transform.gameObject.SetActive(true);

        }
    }
    
    
}
