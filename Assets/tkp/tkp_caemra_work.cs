using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class tkp_caemra_work : MonoBehaviour
{
    private Vector3 mouse_position;
    private GameObject camera_obj;
    private float mouse_delta;

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int x, int y);
    


    // Start is called before the first frame update
    void Start()
    {
        camera_obj = this.gameObject;
        mouse_position = Input.mousePosition;
        mouse_delta = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 delta_camera = camera_obj.transform.position;
        mouse_position = Input.mousePosition;
        mouse_delta = mouse_delta - mouse_position.x;
        if(mouse_position.x > 0)
        {
            delta_camera.x += 0.01f;
        }
        else if(mouse_position.x < 0)
        {
            delta_camera.x -= 0.01f;
        }
        camera_obj.transform.position = delta_camera;

        mouse_delta = mouse_position.x;

        
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("Z");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            // Debug.Log(mouse_position);
            //SetCursorPos(960, 540);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
