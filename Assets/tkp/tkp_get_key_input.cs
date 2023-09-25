using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tkp_get_key_input : MonoBehaviour
{
    private Rigidbody rb;
    private string input_key;
    [SerializeField] private float velocity = 0.01f;
    private bool isground = false;
    private GameObject camera_obj;
    private tkp_caemra_work camera_work;
    //�ő呬�x
    public float max_spd = 10.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //�J�����̃I�u�W�F�N�g���Q�Ƃ���
        camera_obj = GameObject.Find("Main Camera");
        camera_work = camera_obj.GetComponent<tkp_caemra_work>();

    }

    // Update is called once per frame
    void Update()
    {
        Transform now_camera_transform;
        Vector3 add_force;

        now_camera_transform = camera_work.get_camera_vector();
        add_force = new Vector3(0, 0, 0);

        if (Input.anyKey)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(code))
                {
                    // ���͂��ꂽ�L�[����\��
                    input_key = code.ToString();

                    //���͂ɉ����ĉ�������
                    if (input_key == "W") add_force += now_camera_transform.forward;
                    if (input_key == "A") add_force -= now_camera_transform.right;
                    if (input_key == "S") add_force -= now_camera_transform.forward;
                    if (input_key == "D") add_force += now_camera_transform.right;

                }
            }
            
            if (isground)
            {
                if (Input.GetKey(KeyCode.Space)) rb.AddForce(new Vector3(0, 20, 0));
            }
           
            //�ő呬�x�ȏ�ɉ������Ȃ�����
            if ((rb.velocity.x >= max_spd || rb.velocity.x <= -max_spd))
            {
                add_force.x = 0;
            }
            if (rb.velocity.z >= max_spd || rb.velocity.z <= -max_spd)
            {
                add_force.z = 0;
            }
            add_force.y = 0;
            rb.AddForce(add_force * velocity);
        }

    }


    private void OnTriggerStay(Collider other)
    {
        Vector3 add_force;
        add_force = new Vector3(0, 0, 0);

        if(other.gameObject.name == "Stage")
        {
            add_force = rb.velocity;
            add_force.x *= 0.99f;
            add_force.z *= 0.99f;
            rb.velocity = add_force;
            
            isground = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Stage")
        {
            isground = false;
        }
    }
}





