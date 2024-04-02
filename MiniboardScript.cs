using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniboardScript : MonoBehaviour
{
    public GameObject gridPrefab;
    //miniboard의 위치값 (다음 comment 참고)
    public int MBPosition = 4;
    public GameObject[] grids = new GameObject[9];
    //0 1 2
    //3 4 5
    //6 7 8

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
