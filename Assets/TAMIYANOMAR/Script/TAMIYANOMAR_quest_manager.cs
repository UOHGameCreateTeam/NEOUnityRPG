using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_quest_manager : MonoBehaviour
{
    [SerializeField] private GameObject battleManager1;
    [SerializeField] private GameObject battleManager2;
    [SerializeField] private GameObject battleManager3;
    [SerializeField] private string questName;

    [SerializeField] private Vector2 questPosition;

    private bool questClear = false;
    private bool questActive = false;
    private bool questStart = false;
    private bool firstActive1 = false;
    private bool firstActive2 = false;
    private bool firstActive3 = false;



    void Update()
    {

        TAMIYANOMAR_battle_manager t_battle_manager_1 = battleManager1.GetComponent<TAMIYANOMAR_battle_manager>();
        TAMIYANOMAR_battle_manager t_battle_manager_2 = battleManager2.GetComponent<TAMIYANOMAR_battle_manager>();
        TAMIYANOMAR_battle_manager t_battle_manager_3 = battleManager3.GetComponent<TAMIYANOMAR_battle_manager>();

        if (questActive == true && t_battle_manager_1.activated() == false && firstActive1 == false)
        {
            //Debug.Log("setactive 1");
            battleManager1.SetActive(true);
            t_battle_manager_1.setActive();
            firstActive1 = true;
        }

        if (t_battle_manager_1.getBattleClear() == true && t_battle_manager_2.activated() == false && firstActive2 == false)
        {
            //Debug.Log("setactive 2");
            battleManager1.SetActive(false);
            battleManager2.SetActive(true);
            t_battle_manager_2.setActive();
            firstActive2 = false;
        }

        if (t_battle_manager_2.getBattleClear() == true && t_battle_manager_3.activated() == false && firstActive3 == false)
        {
            battleManager2.SetActive(false);
            battleManager3.SetActive(true);
            t_battle_manager_3.setActive();
            firstActive3 = false;
        }

        if (t_battle_manager_3.getBattleClear() == true)
        {
            battleManager3.SetActive(false);
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
