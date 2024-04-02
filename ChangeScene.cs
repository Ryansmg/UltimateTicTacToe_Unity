using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Game()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Help()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void Exit()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }
        else
        {
            #if UNITY_EDITOR
                 UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
