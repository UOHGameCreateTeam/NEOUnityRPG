using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;

public class tkp_Enemy_atk_blow_away : MonoBehaviour
{
    private GameObject player_obj;
    private Rigidbody rb;
    private string input_key;
    private Vector3 add_force;

    public float blow_away_spd = 5.0f;
    public float player_blow_away_limit_y = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのオブジェクトを取得する
        player_obj = GameObject.Find("Player_1");
        rb = player_obj.GetComponent<Rigidbody>();
        add_force.x = 0;
        add_force.y = blow_away_spd;
        add_force.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(player_obj.transform.position.y <= player_blow_away_limit_y){
            if (Input.anyKey)
            {
                foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(code))
                    {
                        // キー入力を文字列に変換
                        input_key = code.ToString();

                        // Pキーの入力で敵が攻撃する（仮）
                        if (input_key == "P") rb.AddForce(add_force);
                    }
                }
            }
        }
        
    }
}
