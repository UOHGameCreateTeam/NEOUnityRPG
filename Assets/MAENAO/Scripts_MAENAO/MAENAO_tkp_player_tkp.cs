using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAENAO_tkp_player_tkp : MonoBehaviour
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
    public int get_hp()
    {
        return hp;
    }
    public void set_hp(int set_values)
    {
        hp = set_values;
    }
}
