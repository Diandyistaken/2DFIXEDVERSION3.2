using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;


        if(Application.isPlaying)
        {
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
