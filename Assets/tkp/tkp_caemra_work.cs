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
        
        camera_rotate = 0;
        sensitivity = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta_camera;
        double tmp_sin, tmp_cos;

        camera_obj.transform.position = inital_camera_position;
        Cursor.lockState = CursorLockMode.None;

        mouse_position = Input.mousePosition;

        if(mouse_position.x > screen_center_position.x)
        {
            camera_rotate += 0.01f;

            tmp_sin = 5 * Math.Sin(camera_rotate * (Math.PI / 180));
            tmp_cos = 5 * Math.Sin(camera_rotate * (Math.PI / 180));

            delta_camera.x = (float)tmp_cos;
            delta_camera.y = 0;
            delta_camera.z = (float)tmp_sin;
            //delta_camera -= cube_obj.transform.position;

            camera_obj.transform.position = cube_obj.transform.position + offset + delta_camera;
            //Debug.Log(delta_camera);
        }
        else if (mouse_position.x == screen_center_position.x)
        {
            //Debug.Log("c");
        }
        else if(mouse_position.x < screen_center_position.x)
        {
            camera_rotate -= 0.01f;

            tmp_sin = 5 * Math.Sin(camera_rotate * (Math.PI / 180));
            tmp_cos = 5 * Math.Sin(camera_rotate * (Math.PI / 180));

            delta_camera.x = (float)tmp_sin;
            delta_camera.y = 0;
            delta_camera.z = (float)tmp_sin;
            //delta_camera -= cube_obj.transform.position;

            camera_obj.transform.position = cube_obj.transform.position + offset + delta_camera;
        }

        /*tmp_sin = 5 * Math.Sin(camera_rotate * (Math.PI / 180));
        tmp_cos = 5 * Math.Sin(camera_rotate * (Math.PI / 180));

        delta_camera.x = (float)tmp_cos;
        delta_camera.y = 0;
        delta_camera.z = (float)tmp_sin;
        delta_camera -= cube_obj.transform.position;

        camera_obj.transform.position = cube_obj.transform.position + offset + delta_camera;*/

        sensitivity += 0.1f;
        if(sensitivity >= 1.5)
        {
            Cursor.lockState = CursorLockMode.Locked;
            screen_center_position = Input.mousePosition;
            sensitivity = 0;
            Debug.Log(camera_rotate);
        }
        


    }
}
