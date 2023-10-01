using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;

public class tkp_Enemy_atk_blow_away : MonoBehaviour
{
    [SerializeField] private int hp;
    private GameObject player_obj;
    private Rigidbody rb;
    private Vector3 add_force;

    public float blow_away_spd = 5.0f;
    public float player_blow_away_limit_y = 10.0f;
    public GameObject wave_prefab;
    public GameObject dmg_area_prefab;
    // 攻撃のサイクル時間
    public int atk_interval = 14500;
    private int now_atk_time = 1;
    //ダメージエリア散布間隔
    public int spray_dmg_area_interval = 30;
    // ダメージエリア散布時間
    public int spray_dmg_area_time = 3000;
    private bool spray_dmg_area_flag = true;

    // ダメージエリアの数を数える
    private int count_dmg_area = 0;
    // ダメージエリアの最大値
    public int num_max_dmg_area = 50;

    // 衝撃波を打つ時間
    public int blow_away_time = 5000;
    // private bool blow_away_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのオブジェクトを取得する
        player_obj = GameObject.Find("Player_1");
        rb = player_obj.GetComponent<Rigidbody>();
        add_force.x = 0;
        add_force.y = blow_away_spd;
        add_force.z = 0;

        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // ダメージエリアの数を数える
        count_dmg_area = GameObject.FindGameObjectsWithTag("dmg_area").Length;
        
        if(player_obj.transform.position.y <= player_blow_away_limit_y){
            if (((now_atk_time % blow_away_time) == 0) && (now_atk_time > spray_dmg_area_time)) 
            {
                spray_dmg_area_flag = false;
                // blow_away_flag = true;
                Instantiate(wave_prefab); 
            }

        }
        if((count_dmg_area <= num_max_dmg_area) && ((now_atk_time % spray_dmg_area_interval) == 0) && (now_atk_time < spray_dmg_area_time))
        {
            Instantiate(dmg_area_prefab, this.gameObject.transform);   
            spray_dmg_area_flag = true;   
            // blow_away_flag = false;    
        }

        if(now_atk_time > spray_dmg_area_time)
        {
            spray_dmg_area_flag = false;
        }

        now_atk_time++;
        if(now_atk_time > atk_interval)
        {
            foreach(GameObject destroy_obj in GameObject.FindGameObjectsWithTag("dmg_area"))
            {
                Destroy(destroy_obj, 0.5f);
            }
            now_atk_time = 1;
        }           
    }

    public int get_atk_interval()
    {
        return atk_interval;
    }
    public int get_now_time()
    {
        return now_atk_time;
    }
    public int get_wave_time()
    {
        return blow_away_time;
    }
    public int get_spray_time()
    {
        return spray_dmg_area_time;
    }

}
