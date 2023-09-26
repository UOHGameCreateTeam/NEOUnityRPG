using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_dmg_area : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject dmg_area_obj;
    private GameObject player_obj;
    
    private Rigidbody rb;
    public int dmg_area_dmg = 1;
    private tkp_player_tkp player_hp;

    // public int destroy_counter = 1000;
    // public int now_destroy_counter = 0;

    void Start()
    {
        float rand_x = Random.Range(-10.0f,10.0f);
        float rand_y = Random.Range(20.0f,40.0f);
        float rand_z = Random.Range(-10.0f,10.0f);
        Vector3 add_force = new Vector3(0,30,0);

        dmg_area_obj = this.gameObject;
        rb = GetComponent<Rigidbody>();

        add_force.x = rand_x;
        add_force.y = rand_y;
        add_force.z = rand_z;

        rb.velocity = add_force;

        // player_obj = GameObject.Find("Player_1");
        // player_hp = player_obj.gameObject.GetComponent<tkp_player_tkp>();        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player_hp.get_hp());
    }

    private void OnTriggerStay(Collider other)
    {
        int now_player_hp;
        if(other.gameObject.name == "Player_1")
        {
            now_player_hp = player_hp.get_hp();

            now_player_hp -= dmg_area_dmg;

            player_hp.set_hp(now_player_hp);

            
        }
        // now_destroy_counter += 1;
        // if(now_destroy_counter > destroy_counter)
        // {
        //     // Destroy(dmg_area_obj);
        // }

        
            
    }
}
