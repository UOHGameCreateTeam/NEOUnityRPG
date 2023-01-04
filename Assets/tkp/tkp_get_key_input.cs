using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tkp_get_key_input : MonoBehaviour
{
    private GameObject cube_game_object;
    private GameObject ground_object;
    private string input_key;
    private Vector3 cube_position;
    private float velocity = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        cube_game_object = this.gameObject;
        ground_object = GameObject.Find("ground");
        Debug.Log(cube_game_object.name);
    }

    // Update is called once per frame
    void Update()
    {
        cube_position = cube_game_object.transform.position;
        /*cube_position.x += velocity;
        cube_game_object.transform.position = cube_position;
        Debug.Log(cube_position);*/

        if (Input.anyKey)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(code))
                {
                    // ì¸óÕÇ≥ÇÍÇΩÉLÅ[ñºÇï\é¶
                    input_key = code.ToString();
                    Debug.Log(input_key);
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
                    
                    cube_position.y += velocity;
                    break;

                case "LeftControl":
                    cube_position.y -= velocity;
                    break;

                default:
                    break;
            }
            Debug.Log(cube_position);
        }
        cube_game_object.transform.position = cube_position;

    }
}
