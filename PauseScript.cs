using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PausePanel;
    public void PauseButton()
    {
        PausePanel.SetActive(true);
    }

    public void CancelButton()
    {
        PausePanel.SetActive(false);
    }
}
