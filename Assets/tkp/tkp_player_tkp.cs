using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_player_tkp : MonoBehaviour
{
    [SerializeField] private int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //hp管理用関数
    //get_hp()　hp取得
    public int get_hp()
    {
        return hp;
    }
    //set_hp() hp書き換え
    public void set_hp(int set_values)
    {
        hp = set_values;
    }
}
