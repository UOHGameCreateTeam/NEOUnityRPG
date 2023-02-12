using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tkp_get_key_input : MonoBehaviour
{
    private GameObject cube_game_object;
    private GameObject ground_object;
    private Rigidbody rb;
    private string input_key;
    private Vector3 cube_position;
    [SerializeField] private float velocity = 0.01f;
    private float obj_rotation = 0.1f;
    private bool isground = false;
    // Start is called before the first frame update
    private GameObject camera_obj;
    private tkp_caemra_work camera_work;
    //最大速度
    public float max_spd = 10.0f;
    void Start()
    {
        cube_game_object = this.gameObject;
        rb = GetComponent<Rigidbody>();
        ground_object = GameObject.Find("Stage");

        //カメラのオブジェクトを参照する
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

        cube_position = cube_game_object.transform.position;
        

        if (Input.anyKey)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(code))
                {
                    // 入力されたキー名を表示
                    input_key = code.ToString();
                    //Debug.Log(input_key);
                }
            }

            switch (input_key)
            {
                case "W":
                    add_force = now_camera_transform.forward;
                    break;

                case "A":
                    add_force = -now_camera_transform.right;
                    break;

                case "D":
                    add_force = now_camera_transform.right;
                    break;

                case "S":
                    add_force = -now_camera_transform.forward;
                    break;

                case "Space":
                    if (isground)
                    {
                        rb.AddForce(new Vector3(0, 20, 0));
                    }
                    break;

                default:
                    break;
            }

            //最大速度以上に加速しない処理
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
        else
        {
            //キー入力がないときにオブジェクトを静止する
            add_force = rb.velocity;
            add_force.x = 0;
            add_force.z = 0;
            rb.velocity = add_force;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Stage")
        {
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





