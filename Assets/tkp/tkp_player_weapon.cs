using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tkp_player_weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player_weapon;
    public GameObject player_bullet;
    private GameObject player;
    private GameObject obj;
    void Start()
    {
        player = GameObject.Find("Player_1");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_pos = player.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            player_pos.y = 3;
            obj = (GameObject)Instantiate(player_weapon, player.transform.position, Quaternion.identity);
            obj.transform.position = player_pos;//player.transform;
            obj.transform.forward = player.transform.forward;
        }

        if (Input.GetMouseButtonDown(1))
        {
            player_pos.y = 10;
            Instantiate(player_bullet, player_pos, Quaternion.identity);


        }
    }
}
