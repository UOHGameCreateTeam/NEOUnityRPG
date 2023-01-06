using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using System;


public class tkp_caemra_work : MonoBehaviour
{
    private Vector3 mouse_position;
    private Vector3 screen_center_position;
    private Vector3 offset;
    private Vector3 inital_camera_position;
    private Vector3 delta_camera;
    private GameObject camera_obj;
    private GameObject cube_obj;
    private float camera_rotate;
    private float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        screen_center_position = Input.mousePosition;
        mouse_position = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;

        camera_obj = this.gameObject;
        cube_obj = GameObject.Find("test_cube_1");
        offset = camera_obj.transform.position - cube_obj.transform.position;
        inital_camera_position = camera_obj.transform.position;
        delta_camera = offset;
        
        camera_rotate = 0;
        sensitivity = 0;
        Debug.Log(cube_obj.transform.position);
        Debug.Log(offset);

        

    }

    // Update is called once per frame
    void Update()
    {
        
        double tmp_sin, tmp_cos;
        float tmp_rot;

        //camera_obj.transform.position = inital_camera_position;
        delta_camera = cube_obj.transform.position;
        Cursor.lockState = CursorLockMode.None;

        mouse_position = Input.mousePosition;

        if(mouse_position.x > screen_center_position.x)
        {
            camera_rotate += 1f;
            //camera_obj.transform.Rotate(0f, -1f, 0f);
        }
        else if (mouse_position.x == screen_center_position.x)
        {
            //camera_rotate += 0;
            //Debug.Log("c");
            //Debug.Log("c" + delta_camera);
        }
        else if(mouse_position.x < screen_center_position.x)
        {
            camera_rotate -= 1f;
            //camera_obj.transform.Rotate(0f, 1f, 0f);
            Debug.Log(delta_camera);
            Debug.Log(camera_rotate);

        }

        tmp_sin = 3.5 * Math.Sin(camera_rotate * (Math.PI / 180));
        tmp_cos = 3.5 * Math.Cos(camera_rotate * (Math.PI / 180));
        
        delta_camera.x += (float)tmp_cos;
        delta_camera.z += (float)tmp_sin;
        tmp_rot = camera_rotate;

        camera_obj.transform.position = delta_camera;
        camera_obj.transform.rotation = Quaternion.Euler(0f, -(90+tmp_rot), 0f);
        

        sensitivity += 0.1f;
        if(sensitivity >= 1.5)
        {
            Cursor.lockState = CursorLockMode.Locked;
            screen_center_position = Input.mousePosition;
            sensitivity = 0;
            //Debug.Log(camera_rotate);
        }
        if(camera_rotate >= 360)
        {
            camera_rotate = 0;
        }
        else if(camera_rotate <= 0)
        {
            camera_rotate = 360;
        }


    }
}
