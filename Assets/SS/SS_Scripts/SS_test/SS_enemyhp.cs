using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_enemyhp : MonoBehaviour
{
    [SerializeField] private int now_hp = 1000;
    // Start is called before the first frame update
    
    public int get_hp() {
        return now_hp;
    }
    public void set_hp(int nokori_hp)
    {
        now_hp = nokori_hp;
    }
}
