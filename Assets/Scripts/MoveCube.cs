using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{

    static private List<Vector3> PlayerPath;
    static private List<Vector3> CubePath;

    static private MoveCube _moveCube;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_moveCube)
        {
            _moveCube = this;
        }
        PlayerPath = new List<Vector3>();
        CubePath = new List<Vector3>();
    }

    public void OnButtonClick()
    {
        if (PlayerPath.Count == 0) return;
        var player = GameObject.FindWithTag("Player");
        var c = player.GetComponent<CharacterController>();
        c.enabled = false;
        player.transform.position = (Vector3)PlayerPath[PlayerPath.Count - 1];
        PlayerPath.RemoveAt(PlayerPath.Count - 1);
        c.enabled = true;
        _moveCube.transform.position = (Vector3)CubePath[CubePath.Count - 1];
        CubePath.RemoveAt(CubePath.Count - 1);
    } 
    
    public void OnButtonClickReset()
    {
        if (PlayerPath.Count == 0) return;
        var player = GameObject.FindWithTag("Player");
        var c = player.GetComponent<CharacterController>();
        c.enabled = false;
        player.transform.position = (Vector3)PlayerPath[0];
        c.enabled = true;
        _moveCube.transform.position = (Vector3)CubePath[0];
        PlayerPath.Clear();
        CubePath.Clear();
    } 

        

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        var playerPosition = collision.gameObject.transform.position;
        var position = transform.position;


        
        var x = playerPosition.x - position.x;
        var z = playerPosition.z - position.z;
        
        
        Debug.Log(x + " " + z);
        if (Mathf.Abs(x) < 1f && z < -0.5)
        {
            if (position.z >= 10) return;
            transform.position = new Vector3(position.x, position.y, position.z + 1);
            PlayerPath.Add(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - 0.2f));
            CubePath.Add(position);

        } else if (Mathf.Abs(x) < 1f && z > 0.5)
        {
            if (position.z <= 2) return;
            transform.position = new Vector3(position.x, position.y, position.z - 1);
            PlayerPath.Add(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + 0.2f));
            CubePath.Add(position);

        } else if (x < -0.5 && Mathf.Abs(z) < 1f)
        {
            if (position.x >= 10) return;
            transform.position = new Vector3(position.x + 1, position.y, position.z);
            PlayerPath.Add(new Vector3(playerPosition.x - 0.2f, playerPosition.y, playerPosition.z));
            CubePath.Add(position);

        } else if (x > 0.5 && Mathf.Abs(z) < 1f)
        {
            if (position.x <= 2) return;
            transform.position = new Vector3(position.x - 1, position.y, position.z);
            PlayerPath.Add(new Vector3(playerPosition.x + 0.2f, playerPosition.y, playerPosition.z));
            CubePath.Add(position);

        }
    }
}
