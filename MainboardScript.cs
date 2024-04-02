using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainboardScript : MonoBehaviour
{
    public GameObject miniBoardPrefab;
    public GameObject[] miniBoards = new GameObject[9]; 
    //0 1 2
    //3 4 5
    //6 7 8

    // Start is called before the first frame update
    void Start()
    {
        miniBoards[0] = Instantiate(miniBoardPrefab);
        miniBoards[0].transform.position = new Vector3(-3.5f, 3.5f, 0);
        miniBoards[0].GetComponent<MiniboardScript>().MBPosition = 0;
        miniBoards[1] = Instantiate(miniBoardPrefab);
        miniBoards[1].transform.position = new Vector3(0, 3.5f, 0);
        miniBoards[1].GetComponent<MiniboardScript>().MBPosition = 1;
        miniBoards[2] = Instantiate(miniBoardPrefab);
        miniBoards[2].transform.position = new Vector3(3.5f, 3.5f, 0);
        miniBoards[2].GetComponent<MiniboardScript>().MBPosition = 2;
        miniBoards[3] = Instantiate(miniBoardPrefab);
        miniBoards[3].transform.position = new Vector3(-3.5f, 0, 0);
        miniBoards[3].GetComponent<MiniboardScript>().MBPosition = 3;
        miniBoards[4] = miniBoardPrefab;
        miniBoards[5] = Instantiate(miniBoardPrefab);
        miniBoards[5].transform.position = new Vector3(3.5f, 0, 0);
        miniBoards[5].GetComponent<MiniboardScript>().MBPosition = 5;
        miniBoards[6] = Instantiate(miniBoardPrefab);
        miniBoards[6].transform.position = new Vector3(-3.5f, -3.5f, 0);
        miniBoards[6].GetComponent<MiniboardScript>().MBPosition = 6;
        miniBoards[7] = Instantiate(miniBoardPrefab);
        miniBoards[7].transform.position = new Vector3(0, -3.5f, 0);
        miniBoards[7].GetComponent<MiniboardScript>().MBPosition = 7;
        miniBoards[8] = Instantiate(miniBoardPrefab);
        miniBoards[8].transform.position = new Vector3(3.5f, -3.5f, 0);
        miniBoards[8].GetComponent<MiniboardScript>().MBPosition = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
