using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVariables : MonoBehaviour
{
    public bool isOTurn = true;
    public GameObject textObj;
    public GameObject selectedGrid;
    public string[] miniBoardStates = { "", "", "", "", "", "", "", "", "" };
    //o, x, n(¹«½ÂºÎ)
    public bool[] isMBTarget = { true, true, true, true, true, true, true, true, true };
    public GameObject WinPanel;
    public GameObject WinText;
    public bool restrictGridInput = true;
    public bool enableCameraMovement = true;
}
