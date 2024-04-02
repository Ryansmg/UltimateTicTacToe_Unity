using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSetting : MonoBehaviour
{
    public void ChangeCamera()
    {
        if (GameObject.Find("Scripts").GetComponent<MainVariables>().enableCameraMovement)
        {
            GameObject.Find("Scripts").GetComponent<MainVariables>().enableCameraMovement = false;
            GameObject.Find("CameraSettingText").GetComponent<Text>().text = "ī�޶� ������ Ȱ��ȭ�ϱ�";
        } else
        {
            GameObject.Find("Scripts").GetComponent<MainVariables>().enableCameraMovement = true;
            GameObject.Find("CameraSettingText").GetComponent<Text>().text = "ī�޶� ������ ��Ȱ��ȭ�ϱ�";
        }
    }
}
