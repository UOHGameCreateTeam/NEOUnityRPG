using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_enemy_addD : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int e_damage = 30;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.tag == "Player")
        {

            this.GetComponent<SS_EnemyJump>().enabled = false;
            addDamage(e_damage, Player);
        }


    }
    private void addDamage(int damage, GameObject gameobject)
    {
        Debug.Log(damage);
        int now_hp = gameobject.GetComponent<tkp_player_tkp>().get_hp();
        gameobject.GetComponent<tkp_player_tkp>().set_hp(now_hp - damage);
    }
}
