using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_player_move_area : MonoBehaviour
{
    private GameObject player_obj;
    private Rigidbody rb;
    private bool flag = true;
    public float player_move_limit_x = 1000.0f;
    public float player_move_limit_y = 10.0f;
    public float player_move_limit_z = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのオブジェクトを取得する
        player_obj = GameObject.Find("Player_1");
        rb = player_obj.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float now_player_position_y;

        now_player_position_y = player_obj.transform.position.y;

        if(now_player_position_y >= player_move_limit_y){
            if(flag){
                rb.velocity = Vector3.zero;
                flag = false;
            }
        }
        else{
            flag = true;
        }
        

        // Debug.Log(player_obj.transform.position);
        
    }
}
