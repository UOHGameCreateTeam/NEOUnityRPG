using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_give_damage : MonoBehaviour
{
    [SerializeField] int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "test_cube_1")
        {
            tkp_player_tkp player_hp = collision.gameObject.GetComponent<tkp_player_tkp>();
            player_hp.set_hp(player_hp.get_hp() - damage);
            Debug.Log("give damage");
            Debug.Log(player_hp);
            this.gameObject.SetActive(false);
        }
    }
}
