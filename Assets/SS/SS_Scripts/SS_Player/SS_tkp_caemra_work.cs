using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using System;


public class SS_tkp_caemra_work : MonoBehaviour
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
    private float camera_rotate;
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
        cube_obj = GameObject.Find("Player");
       
        //初期設定
        camera_rotate = 0;
        sensitivity = 0;        

    }

    // Update is called once per frame
    void Update()
    {
        
        double tmp_sin, tmp_cos;
        float tmp_rot;

        delta_camera = cube_obj.transform.position;
        delta_camera.y += 5;
        delta_camera.z += -5;
        //カーソルロック解除
        Cursor.lockState = CursorLockMode.None;

        mouse_position = Input.mousePosition;

        //マウスが左右どちらに動いたのかを取得、カメラの回転方向を決定
        if((mouse_position.x - screen_center_position.x) > sensitivity_theta || (mouse_position.x - screen_center_position.x) < sensitivity_theta)
        {
            if (mouse_position.x > screen_center_position.x)
            {
                camera_rotate += camera_velocity;
            }
            else if (mouse_position.x == screen_center_position.x)
            {

            }
            else if (mouse_position.x < screen_center_position.x)
            {
                camera_rotate -= camera_velocity;
            }
        }


        //カメラの座標を計算
        tmp_sin = 3.5 * Math.Sin(camera_rotate * (Math.PI / 180));
        tmp_cos = 3.5 * Math.Cos(camera_rotate * (Math.PI / 180));
        
        delta_camera.x += (float)tmp_cos;
        delta_camera.z += (float)tmp_sin;
        tmp_rot = camera_rotate;

        //カメラの移動
        camera_obj.transform.position = delta_camera;
        //カメラ本体の回転
        camera_obj.transform.rotation = Quaternion.Euler(0f, -(90+tmp_rot), 0f);
        
        //感度の処理
        sensitivity += 0.1f;
        if(sensitivity >= 1.5)
        {
            Cursor.lockState = CursorLockMode.Locked;
            screen_center_position = Input.mousePosition;
            sensitivity = 0;
           
        }
        //オーバーフロー防止
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
