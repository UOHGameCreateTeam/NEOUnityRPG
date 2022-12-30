using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_quest_manager : MonoBehaviour
{
    [SerializeField] private GameObject battleManager1;
    [SerializeField] private GameObject battleManager2;
    [SerializeField] private GameObject battleManager3;

    private bool questClear = false;

    private bool questActive = false;


    // Update is called once per frame
    void Update()
    {
        TAMIYANOMAR_battle_manager t_battle_manager_1 = battleManager1.GetComponent<TAMIYANOMAR_battle_manager>();
        TAMIYANOMAR_battle_manager t_battle_manager_2 = battleManager2.GetComponent<TAMIYANOMAR_battle_manager>();
        TAMIYANOMAR_battle_manager t_battle_manager_3 = battleManager3.GetComponent<TAMIYANOMAR_battle_manager>();

        if (questActive == true)
        {
            t_battle_manager_1.setActive();
        }

        if (t_battle_manager_1.getBattleClear() == true)
        {
            t_battle_manager_2.setActive();
        }

        if (t_battle_manager_2.getBattleClear() == true)
        {
            t_battle_manager_3.setActive();
        }

        if (t_battle_manager_3.getBattleClear() == true)
        {
            questClear = true;
        }
    }

    public bool getQuestClear()
    {
        return questClear;
    }

    public void setActive()
    {
        questActive = true;
    }
}
