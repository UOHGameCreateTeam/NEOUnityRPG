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
    void Start()
    {
        cube_game_object = this.gameObject;
        rb = GetComponent<Rigidbody>();
        ground_object = GameObject.Find("ground");
    }

    // Update is called once per frame
    void Update()
    {
        cube_position = cube_game_object.transform.position;
        

        if (Input.anyKey)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(code))
                {
                    // ì¸óÕÇ≥ÇÍÇΩÉLÅ[ñºÇï\é¶
                    input_key = code.ToString();
                    //Debug.Log(input_key);
                }
            }

            switch (input_key)
            {
                case "A":
                    cube_position.x += velocity;
                    break;

                case "D":
                    cube_position.x -= velocity;
                    break;

                case "S":
                    cube_position.z += velocity;
                    break;

                case "W":
                    cube_position.z -= velocity;
                    break;

                case "Space":
                   if (isground)
                   {
                        rb.AddForce(new Vector3(0,20,0));
                   }                    
                    break;

                case "LeftControl":
                    cube_position.y -= velocity;
                    break;

                case "Q":
                    cube_game_object.transform.Rotate(new Vector3(0, obj_rotation, 0));
                    break;

                case "E":
                    cube_game_object.transform.Rotate(new Vector3(0, -obj_rotation, 0));
                    break;

                default:
                    break;
            }
            //Debug.Log(cube_position);
        }
        cube_game_object.transform.position = cube_position;

    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "ground")
        {
            isground = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ground")
        {
            isground = false;
        }
    }
}





