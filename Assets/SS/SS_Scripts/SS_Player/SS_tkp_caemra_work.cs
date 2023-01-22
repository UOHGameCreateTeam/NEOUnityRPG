using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using System;


public class SS_tkp_caemra_work : MonoBehaviour
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
    private float camera_rotate;
    //���x�H
    private float sensitivity;
    //���̒l�𒴂���ƃJ����������
    public float sensitivity_theta = 1;
    //�J�����̑���
    public float camera_velocity = 1;

    // Start is called before the first frame update
    void Start()
    {
        //���܂��Ȃ�
        Cursor.lockState = CursorLockMode.Locked;
        screen_center_position = Input.mousePosition;
        mouse_position = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;

        //�I�u�W�F�N�g�擾
        camera_obj = this.gameObject;
        cube_obj = GameObject.Find("Player");
       
        //�����ݒ�
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
        //�J�[�\�����b�N����
        Cursor.lockState = CursorLockMode.None;

        mouse_position = Input.mousePosition;

        //�}�E�X�����E�ǂ���ɓ������̂����擾�A�J�����̉�]����������
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


        //�J�����̍��W���v�Z
        tmp_sin = 3.5 * Math.Sin(camera_rotate * (Math.PI / 180));
        tmp_cos = 3.5 * Math.Cos(camera_rotate * (Math.PI / 180));
        
        delta_camera.x += (float)tmp_cos;
        delta_camera.z += (float)tmp_sin;
        tmp_rot = camera_rotate;

        //�J�����̈ړ�
        camera_obj.transform.position = delta_camera;
        //�J�����{�̂̉�]
        camera_obj.transform.rotation = Quaternion.Euler(0f, -(90+tmp_rot), 0f);
        
        //���x�̏���
        sensitivity += 0.1f;
        if(sensitivity >= 1.5)
        {
            Cursor.lockState = CursorLockMode.Locked;
            screen_center_position = Input.mousePosition;
            sensitivity = 0;
           
        }
        //�I�[�o�[�t���[�h�~
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
