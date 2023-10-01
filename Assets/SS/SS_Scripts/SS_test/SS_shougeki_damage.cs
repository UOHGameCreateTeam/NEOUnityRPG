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
        
            
            if (collision.gameObject.tag == "ground")
            {
                Debug.Log("‚¶‚ß‚ñ");
            }
            if (collision.gameObject.tag == "test_cube_1")
            {
                Debug.Log("“–‚½‚Á‚½");
                addDamage(e_damage, gameObject);
            }
      




    }
    private void addDamage(int damage, GameObject gameobject)
    {
        Debug.Log(damage);
        int now_hp = gameobject.GetComponent<tkp_player_tkp>().get_hp();
        gameobject.GetComponent<tkp_player_tkp>().set_hp(now_hp - damage);
    }
}
