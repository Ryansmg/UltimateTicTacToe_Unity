using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScrollButton : MonoBehaviour
{
    static int page = 0;
    Vector3 v3 = new Vector3(0, 10000, 0);
    private void Start()
    {
        page = 0;
    }
    public void Left()
    {
        if (page == 0) { return; }
        GameObject.Find("PanelsList").GetComponent<Panels>().panels[page].transform.localPosition = v3;
        page--;
        GameObject.Find("PanelsList").GetComponent<Panels>().panels[page].transform.localPosition = Vector3.zero;
    }

    public void Right() { 
        if(page == 8) { SceneManager.LoadScene("TitleScene"); return; }
        GameObject.Find("PanelsList").GetComponent<Panels>().panels[page].transform.localPosition = v3;
        page++;
        GameObject.Find("PanelsList").GetComponent<Panels>().panels[page].transform.localPosition = Vector3.zero;
    }
}
