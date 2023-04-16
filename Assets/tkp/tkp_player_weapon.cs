using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tkp_player_weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player_weapon;
    private GameObject player;
    private GameObject obj;
    void Start()
    {
        player = GameObject.Find("Player_1");
        //obj = (GameObject)Instantiate(player_weapon,player.transform.position,Quaternion.identity);
        //obj.transform.parent = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            obj = (GameObject)Instantiate(player_weapon, player.transform.position, Quaternion.identity);
            obj.transform.parent = player.transform;
        }
    }
}
