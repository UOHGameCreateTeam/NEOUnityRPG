using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using System;


public class tkp_caemra_work : MonoBehaviour
{
    //マウスの座標取得する
    private Vector3 mouse_position;
    //画面中央の座標
    private Vector3 screen_center_position;
    //カメラの座標
    private Vector3 delta_camera;
    //カメラと被写体のオブジェクト
    private GameObject camera_obj;
    private GameObject cube_obj;
    //カメラの回転角度
    private float camera_rotate_h;
    private float camera_rotate_v;
    //カメラと被写体の距離
    private float r = 3.5f;
    //感度？
    private float sensitivity;
    //この値を超えるとカメラが動く
    public float sensitivity_theta = 1;
    //カメラの速さ
    public float camera_velocity = 1;

    // Start is called before the first frame update
    void Start()
    {
        //おまじない
        Cursor.lockState = CursorLockMode.Locked;
        screen_center_position = Input.mousePosition;
        mouse_position = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;

        //オブジェクト取得
        camera_obj = this.gameObject;
        cube_obj = GameObject.Find("test_cube_1");
       
        //初期設定
        camera_rotate_h = 0;
        camera_rotate_v = 0;
        sensitivity = 0;        

    }

    // Update is called once per frame
    void Update()
    {

        double tmp_x, tmp_y, tmp_z, r_dash;
        float theta, phi;

        delta_camera = cube_obj.transform.position;
        //カーソルロック解除
        //Cursor.lockState = CursorLockMode.None;

        mouse_position = Input.mousePosition;

        //マウスが左右どちらに動いたのかを取得、カメラの回転方向を決定
        if((mouse_position.x - screen_center_position.x) > sensitivity_theta || (mouse_position.x - screen_center_position.x) < sensitivity_theta)
        {
            if (mouse_position.x > screen_center_position.x)
            {
                camera_rotate_h += camera_velocity;
            }
            else if (mouse_position.x == screen_center_position.x)
            {

            }
            else if (mouse_position.x < screen_center_position.x)
            {
                camera_rotate_h -= camera_velocity;
            }
        }
        //マウスが上下どちらに動いたのかを取得、カメラの回転方向を決定
        if ((mouse_position.y - screen_center_position.y) > sensitivity_theta || (mouse_position.y - screen_center_position.y) < sensitivity_theta)
        {
            if (mouse_position.y > screen_center_position.y)
            {
                if(camera_rotate_v < 90)
                {
                    camera_rotate_v += camera_velocity;
                }
                
            }

            else if (mouse_position.y < screen_center_position.y)
            {
                if(camera_rotate_v > 0)
                {
                    camera_rotate_v -= camera_velocity;
                }

            }
        }


        //カメラの座標を計算
        r_dash = r * Math.Cos(camera_rotate_v * (Math.PI / 180));
        //垂直方向
        tmp_y = r * Math.Sin(camera_rotate_v * (Math.PI / 180));
        //水平方向
        tmp_z = r_dash * Math.Sin(camera_rotate_h * (Math.PI / 180));
        tmp_x = r_dash* Math.Cos(camera_rotate_h * (Math.PI / 180));

        delta_camera.x += (float)tmp_x;
        delta_camera.y += (float)tmp_y;
        delta_camera.z += (float)tmp_z;
        theta = camera_rotate_h;
        phi = camera_rotate_v;

        //カメラの移動
        camera_obj.transform.position = delta_camera;
        //カメラ本体の回転
        camera_obj.transform.rotation = Quaternion.Euler(phi, -(90+theta), 0f);

        Cursor.lockState = CursorLockMode.Locked;
        screen_center_position = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;

        //感度の処理
        sensitivity += 0.001f;
        if(sensitivity >= 0.01f)
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //screen_center_position = Input.mousePosition;
            //Cursor.lockState = CursorLockMode.None;
            sensitivity = 0;
           
        }
        //オーバーフロー防止
        if(camera_rotate_h >= 360)
        {
            camera_rotate_h = 0;
        }
        else if(camera_rotate_h <= 0)
        {
            camera_rotate_h = 360;
        }


    }
}
