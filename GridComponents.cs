using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridComponents : MonoBehaviour
{
    public GameObject O;
    public GameObject X;
    public GameObject X2;
    public string state = "";
    public bool isSelected;
    public GameObject miniboard;
    public int position;

    private void Update()
    {
        if(state.Equals("O")) { state = "o"; }
        if(state.Equals("X")) { state = "x"; }
    }
}
