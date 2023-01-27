using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_battle_manager : MonoBehaviour
{
    [SerializeField] private GameObject Enemy_1;
    [SerializeField] private GameObject Enemy_2;
    [SerializeField] private GameObject Enemy_3;

    [SerializeField] private GameObject battleDestination;
    private Vector2 battlePosition;
    [SerializeField] private GameObject preManager;

    private bool battleClear = false;

    private bool battleActive = false;

    private bool battleStart = false;

    private bool firstActive = false;

    private void Start()
    {
        battlePosition = new Vector2(battleDestination.transform.position.x, battleDestination.transform.position.z);
    }

    void Update()
    {
        //Debug.Log("battlestart = " + battleStart);
        //Debug.Log("battleClear = " + battleClear);
        //Debug.Log("battleActivate = " + battleActive);

        TAMIYANOMAR_pre_manager t_premanager = preManager.GetComponent<TAMIYANOMAR_pre_manager>();


        if (battleActive == true)
        {
            if (battleStart == false && firstActive == false)
            {
                TAMIYANOMAR_pre_manager t_pre_Manager = preManager.GetComponent<TAMIYANOMAR_pre_manager>();
                t_pre_Manager.setActive(battlePosition);
                firstActive = true;
            }

            if (t_premanager.getArrived() == true)
            {
                battleStart = true;
            }

            if (t_premanager.getArrived() == true && battleClear == false)
            {
                Debug.Log("battle start");
                Enemy_1.SetActive(true);
                Enemy_2.SetActive(true);
                Enemy_3.SetActive(true);

                int enemy_hp_1 = Enemy_1.GetComponent<SS_enemy_hp>().getHp();
                int enemy_hp_2 = Enemy_2.GetComponent<SS_enemy_hp>().getHp();
                int enemy_hp_3 = Enemy_3.GetComponent<SS_enemy_hp>().getHp();

                if (enemy_hp_1 <= 0)
                {
                    Enemy_1.SetActive(false);
                }
                if (enemy_hp_2 <= 0)
                {
                    Enemy_2.SetActive(false);
                }
                if (enemy_hp_3 <= 0)
                {
                    Enemy_3.SetActive(false);
                }
                if (enemy_hp_1 <= 0 && enemy_hp_2 <= 0 && enemy_hp_3 <= 0)
                {
                    Debug.Log("battle cleaar");
                    battleClear = true;
                    battleStart = false;
                    battleActive = false;
                }
            }
        }



    }

    public bool getBattleClear()
    {
        if (battleClear == true)
        {
            battleClear = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setActive()
    {
        Debug.Log("setactive");
        battleActive = true;
        battleClear = false;
        battleStart = false;
        firstActive = false;
    }

    public bool activated()
    {
        return battleActive;
    }
}
