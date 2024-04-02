using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomSpeed;
    public Camera mainCamera;
    public float outerPositionChange;
    static int zoomInt = 0; //zoominÇÑ È½¼ö
    private void Start()
    {
        zoomInt = 0;
    }
    public void ZoomIn()
    {
        if(zoomInt >= 7)
        {
            return;
        }
        mainCamera.orthographicSize -= zoomSpeed;
        OneTouchCameraMoveManager.outerPosition += outerPositionChange;
        zoomInt++;
    }

    public void ZoomOut()
    {
        if(zoomInt == 0)
        {
            return;
        }
        mainCamera.orthographicSize += zoomSpeed;
        OneTouchCameraMoveManager.outerPosition -= outerPositionChange;
        zoomInt--;
    }
}
