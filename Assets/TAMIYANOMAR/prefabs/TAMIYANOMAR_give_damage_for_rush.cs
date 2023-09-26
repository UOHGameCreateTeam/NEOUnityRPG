using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_give_damage_for_rush : MonoBehaviour
{
    [SerializeField] private GameObject enemy_obj;
    [SerializeField] private GameObject player_obj;
    [SerializeField] private GameObject dummy;

    private TAMIYANOMAR_enemy2_move TEnemy2Move;
    private Rigidbody player_rb;
    public float expansion_speed = 0.1f;
    public float max_wave_size = 10.0f;
    private Vector3 add_force;
    [SerializeField] private int damage = 0;

    void Start()
    {
        TEnemy2Move = enemy_obj.GetComponent<TAMIYANOMAR_enemy2_move>();
        player_rb = player_obj.GetComponent<Rigidbody>();
        // êÅÇ´îÚÇŒÇµÇÃã≠Ç≥Ç∆å¸Ç´Çê›íË
        add_force.x = 0;
        add_force.y = 0;//blow_away_spd;
        add_force.z = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
            
        if (collision.gameObject.tag == "test_cube_1")
        {
            //if (player_obj.transform.position.y <= player_blow_away_limit_y)
            {
                add_force.x = (player_obj.transform.position.x - dummy.transform.position.x ) * 35;
                add_force.z = (player_obj.transform.position.z - dummy.transform.position.z ) * 35;
                player_rb.AddForce(add_force, ForceMode.Impulse);
                player_rb.AddForce(Vector3.up * 22, ForceMode.Impulse);
                //player_rb.velocity = add_force;
                Debug.Log(player_rb.velocity);
            }
            tkp_player_tkp player_hp = collision.gameObject.GetComponent<tkp_player_tkp>();
            player_hp.set_hp(player_hp.get_hp() - damage);
            TEnemy2Move.gaveDamage();

        }

        
    }
}
