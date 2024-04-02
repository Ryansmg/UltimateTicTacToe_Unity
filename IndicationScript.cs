using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicationScript : MonoBehaviour
{
    public int position;
    private void Update()
    {
        switch (GameObject.Find("Scripts").GetComponent<MainVariables>().miniBoardStates[position]) {
            case "o":
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 100 / 255f);
                break;
            case "x":
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 131, 1, 100 / 255f);
                break;
            case "n":
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 100 / 255f);
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;
        }
        if (GameObject.Find("Scripts").GetComponent<MainVariables>().isMBTarget[position])
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(125/255f, 255, 100/255f, 100 / 255f);
        }
    }
}
