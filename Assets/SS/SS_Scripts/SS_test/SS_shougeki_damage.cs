using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_shougeki_damage : MonoBehaviour
{
    [SerializeField] private int e_damage = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {

        Debug.Log("aaaa");
            if (collision.gameObject.tag == "ground")
            {
                Debug.Log("じめん");
            }
            if (collision.gameObject.tag == "test_cube_1")
            {
                Debug.Log("当たった");
                addDamage(e_damage, collision.gameObject);
            }

    }
    private void addDamage(int damage, GameObject gameobject)
    {
        Debug.Log(damage);
        int now_hp = gameobject.GetComponent<tkp_player_tkp>().get_hp();
        gameobject.GetComponent<tkp_player_tkp>().set_hp(now_hp - damage);
    }
}
