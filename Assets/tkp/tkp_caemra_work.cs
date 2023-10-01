using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using System;


public class tkp_caemra_work : MonoBehaviour
{
    //�}�E�X�̍��W�擾����
    private Vector3 mouse_position;
    //��ʒ����̍��W
    private Vector3 screen_center_position;
    //�J�����̍��W
    private Vector3 delta_camera;
    //�J�����Ɣ�ʑ̂̃I�u�W�F�N�g
    private GameObject camera_obj;
    private GameObject cube_obj;
    //�J�����̉�]�p�x
    private float camera_rotate_h;
    private float camera_rotate_v;
    //�J�����Ɣ�ʑ̂̋���
    public float r = 3.5f;
   
    //���x�H
    private bool mouse_lock = true;
    private float sensitivity;
    //���̒l�𒴂���ƃJ����������
    public float sensitivity_theta = 1;
    //�J�����̑���
    public float camera_velocity = 1;
    public float camera_offset_y = 0.0f;

    // 画面を見やすくする処理
    public float camera_offset_rad = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        //��ʒ����̍��W���擾
        screen_center_position.x = Screen.width / 2;
        screen_center_position.y = Screen.height / 2;

        mouse_position = Input.mousePosition;

        //�I�u�W�F�N�g�擾
        camera_obj = this.gameObject;
        cube_obj = GameObject.Find("Player_1");
       
        //�����ݒ�
        camera_rotate_h = 0;
        camera_rotate_v = 0;
        sensitivity = 0;

        //�J�[�\��������
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        double tmp_x, tmp_y, tmp_z, r_dash;
        float theta, phi;

        delta_camera = cube_obj.transform.position;
        // delta_camera.x += camera_offset_x;
        delta_camera.y += camera_offset_y;
        // delta_camera.z += camera_offset_z;

        if (mouse_lock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            screen_center_position = Input.mousePosition;
            mouse_lock = false;  
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouse_position = Input.mousePosition;
            mouse_lock = true;
        }

        //�}�E�X�����E�ǂ���ɓ������̂����擾�A�J�����̉�]����������
        if ((mouse_position.x - screen_center_position.x) > sensitivity_theta || (mouse_position.x - screen_center_position.x) < (-sensitivity_theta))
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
        //�}�E�X���㉺�ǂ���ɓ������̂����擾�A�J�����̉�]����������
        if ((mouse_position.y - screen_center_position.y) > sensitivity_theta || (mouse_position.y - screen_center_position.y) < (-sensitivity_theta))
        {
            if (mouse_position.y > screen_center_position.y)
            {
                if (camera_rotate_v < 90)
                {
                    camera_rotate_v += camera_velocity;
                }

            }

            else if (mouse_position.y < screen_center_position.y)
            {
                if (camera_rotate_v > -30)
                {
                    camera_rotate_v -= camera_velocity;
                }

            }
        }


        //�J�����̍��W���v�Z
        r_dash = r * Math.Cos(camera_rotate_v * (Math.PI / 180));
        //��������
        tmp_y = r * Math.Sin(camera_rotate_v * (Math.PI / 180));
        //��������
        tmp_z = r_dash * Math.Sin((camera_rotate_h + camera_offset_rad) * (Math.PI / 180));
        tmp_x = r_dash * Math.Cos((camera_rotate_h + camera_offset_rad) * (Math.PI / 180));

        delta_camera.x += (float)tmp_x;
        delta_camera.y += (float)tmp_y;
        delta_camera.z += (float)tmp_z;
        theta = camera_rotate_h;
        phi = camera_rotate_v;

        //�J�����̈ړ�
        camera_obj.transform.position = delta_camera;
        //�J�����{�̂̉�]
        camera_obj.transform.rotation = Quaternion.Euler(phi, -(90 + theta), 0f);


        //�I�[�o�[�t���[�h�~
        if (camera_rotate_h >= 360)
        {
            camera_rotate_h = 0;
        }
        else if(camera_rotate_h <= 0)
        {
            camera_rotate_h = 360;
        }
        //Debug.Log(camera_obj.transform.forward);
    }
    public Transform get_camera_vector()
    {
        return camera_obj.transform;
    }
}
