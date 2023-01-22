using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_enemy_hp : MonoBehaviour
{
    [SerializeField] private int EnemyHp = 100;

    public void setHp(int setValue)
    {
        EnemyHp = setValue;
    }
    public int getHp()
    {
        return EnemyHp;
    }
}
