using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_enemy_manager : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    float Cot = 0;
    int ctt = 0;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.GetComponent<SS_ground_shock>().enabled = false;
        Enemy.GetComponent<SS_EnemyJump>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Cot);
        Cot += Time.deltaTime;
        if (Cot >= 2 && ctt == 0)
        {
            int rnd = Random.Range(1, 10);
            if (rnd % 2 == 0)
            {
                //Debug.Log("a");
                Enemy.GetComponent<SS_ground_shock>().enabled = true;
                Enemy.GetComponent<SS_ground_shock>().Initialize();
            }
            else
            {
                //Debug.Log("b");
                Enemy.GetComponent<SS_EnemyJump>().enabled = true;
                Enemy.GetComponent<SS_EnemyJump>().Initialize();
            }
            ctt = 1;
        }
        if (Cot >= 7 && ctt == 1)
        {
            //Debug.Log("c");
            ctt = 0;
            Cot = 0;
        }
    }
}
