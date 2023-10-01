using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_player_bullet : MonoBehaviour
{
    public int exist_time = 100;
    private int now_exist_time = 0;
    public int atk_pow = 100;
    public float bullet_v = 1.0f;

    private GameObject player_obj;
    private Vector3 player_forward;
    public int throw_pow = 10;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 add_force;
        player_obj = GameObject.Find("Player_1");

        this.gameObject.transform.forward = player_obj.transform.forward;
        add_force = this.gameObject.transform.forward;

        add_force.x *= throw_pow;
        add_force.y *= throw_pow;
        add_force.z *= throw_pow;
        rb = this.gameObject.GetComponent<Rigidbody>();

        rb.AddForce(add_force);
    }

    // Update is called once per frame
    void Update()
    {
        if(now_exist_time > exist_time)
        {
            Destroy(this.gameObject,0.5f);
            now_exist_time = 0;
        }
        now_exist_time += 1;

    }

    private void OnTriggerEnter(Collider other) 
    {
        int enemy_hp;
        Debug.Log("hit");
        if (other.gameObject.tag == "Enemy")
        {
            enemy_hp = other.gameObject.GetComponent<SS_enemy_hp>().getHp();
            enemy_hp = enemy_hp - atk_pow;
            
            other.gameObject.GetComponent<SS_enemy_hp>().setHp(enemy_hp);

            Debug.Log("hit_enemy");
            Debug.Log(other.gameObject.GetComponent<SS_enemy_hp>().getHp());
            
            Destroy(this.gameObject);
        }

        if (other.gameObject.name == "Stage")
        {
            Destroy(this.gameObject,1.0f);
        }

    }
}
