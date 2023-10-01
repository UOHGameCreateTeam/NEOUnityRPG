using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_blow_wave : MonoBehaviour
{
    private GameObject wave_obj;
    private GameObject enemy_obj;
    private GameObject player_obj;
    private Rigidbody player_rb;
    private Vector3 init_size;
    private Vector3 expansion_rate;
    public float expansion_speed = 0.1f;
    public float max_wave_size = 10.0f;
    // プレイヤーが吹き飛ばされる上限の高さ
    public float player_blow_away_limit_y = 10.0f;
    // 吹き飛ばされる強さと向き
    public float blow_away_spd = 5.0f;
    private Vector3 add_force;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.wave_wave, SourceData.Source.wave);
        wave_obj = this.gameObject;
        enemy_obj = GameObject.Find("tkp_Enemy");

        player_obj = GameObject.Find("Player_1");
        player_rb = player_obj.GetComponent<Rigidbody>();

        init_size = wave_obj.transform.localScale;
        init_size.y = 0.1f;

        // 拡大する倍率
        expansion_rate.x = 3.0f;
        expansion_rate.y = 1.5f;
        expansion_rate.z = 3.0f;

        // 吹き飛ばしの強さと向きを設定
        add_force.x = 0;
        add_force.y = blow_away_spd;
        add_force.z = 0;

    }

    // Update is called once per frame
    void Update()
    {
       
        if(wave_obj.transform.localScale.x > max_wave_size)
        {
            // wave_obj.transform.localScale = init_size;
            Destroy(wave_obj, 0.5f);
        }
        else
        {
            wave_obj.transform.position = enemy_obj.transform.position;

            expansion_rate.x += expansion_speed;
            expansion_rate.z += expansion_speed;

            wave_obj.transform.localScale = expansion_rate;
        }
        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        // Debug.Log(player_obj.transform.position);
        
        if(collision.gameObject.name == "Player_1")
        {
            if(player_obj.transform.position.y <= player_blow_away_limit_y)
            {
                add_force.x = (player_obj.transform.position.x - enemy_obj.transform.position.x) * 40;
                add_force.z = (player_obj.transform.position.z - enemy_obj.transform.position.z) * 40;
                player_rb.AddForce(add_force);
                         
            }

            
        }
    }
}
