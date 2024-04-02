using UnityEngine;
using System.Collections;

public class OneTouchCameraMoveManager : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    public static float outerPosition = 0f;

    private void Start()
    {
        outerPosition = 0f;
    }
    void Update()
    {


        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }
            if (!Input.GetMouseButton(0)) { return; }
            Camera camera = GetComponent<Camera>();
            if (camera.transform.position.x < -outerPosition)
            {
                camera.transform.position = new Vector3(-outerPosition, camera.transform.position.y, -10);
            }
            if (camera.transform.position.x > outerPosition)
            {
                camera.transform.position = new Vector3(outerPosition, camera.transform.position.y, -10);
            }
            if (camera.transform.position.y < -outerPosition)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, -outerPosition, -10);
            }
            if (camera.transform.position.y > outerPosition)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, outerPosition, -10);
            }
            if (!GameObject.Find("Scripts").GetComponent<MainVariables>().enableCameraMovement) { return; }

            Vector2 pos = dragOrigin - Input.mousePosition;
            float x = dragSpeed * pos.x;
            float y = dragSpeed * pos.y;
            camera.transform.position = new Vector3(camera.transform.position.x + x, camera.transform.position.y + y, -10);

            if(camera.transform.position.x < -outerPosition)
            {
                camera.transform.position = new Vector3(-outerPosition, camera.transform.position.y, -10);
            }
            if (camera.transform.position.x > outerPosition)
            {
                camera.transform.position = new Vector3(outerPosition, camera.transform.position.y, -10);
            }
            if (camera.transform.position.y < -outerPosition)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, -outerPosition, -10);
            }
            if (camera.transform.position.y > outerPosition)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, outerPosition, -10);
            }

        }

        dragOrigin = Input.mousePosition;
    }


}