using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_quest_manager : MonoBehaviour
{
    [SerializeField] private GameObject battleManager1;
    [SerializeField] private GameObject battleManager2;
    [SerializeField] private GameObject battleManager3;
    [SerializeField] private GameObject battleManager4;
    [SerializeField] private GameObject battleManager5;

    [SerializeField] private string questName;

    [SerializeField] private Vector2 questPosition;

    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject warp_area;

    private bool questClear = false;
    private bool questActive = false;
    private bool questStart = false;
    private bool firstActive1 = false;
    private bool firstActive2 = false;
    private bool firstActive3 = false;
    private bool firstActive4 = false;
    private bool firstActive5 = false;

    private int battleFigure = 0;

    void Update()
    {
        TAMIYANOMAR_battle_manager t_battle_manager_1 = null;
        TAMIYANOMAR_battle_manager t_battle_manager_2 = null;
        TAMIYANOMAR_battle_manager t_battle_manager_3 = null;
        TAMIYANOMAR_battle_manager t_battle_manager_4 = null;
        TAMIYANOMAR_battle_manager t_battle_manager_5 = null;

        if (battleFigure == 0)
        {
            if (battleManager2 == null)
            {
                battleFigure = 1;
            }
            else if (battleManager3 == null)
            {
                battleFigure = 2;
            }
            else if (battleManager4 == null)
            {
                battleFigure = 3;
                Debug.Log(battleFigure);
            }
            else if (battleManager5 == null)
            {
                battleFigure = 4;
            }
            else
            {
                battleFigure = 5;
            }
        }

        if (battleManager1 != null)
        {
            t_battle_manager_1 = battleManager1.GetComponent<TAMIYANOMAR_battle_manager>();
            if (t_battle_manager_1.getBattleClear() == true && battleFigure == 1)
            {
                questClear = true;
                
            }
        }

        if (battleManager2 != null)
        {
            t_battle_manager_2 = battleManager2.GetComponent<TAMIYANOMAR_battle_manager>();
            if (t_battle_manager_2.getBattleClear() == true && battleFigure == 2)
            {
                questClear = true;
            }
        }
        if (battleManager3 != null)
        {
            t_battle_manager_3 = battleManager3.GetComponent<TAMIYANOMAR_battle_manager>();
            if (t_battle_manager_3.getBattleClear() == true && battleFigure == 3)
            {
                questClear = true;
                if (gate != null)
                {
                    gate.GetComponent<TAMIYANOMAR_gete_manager>().gateDelete();
                }
                if (warp_area != null)
                {
                    warp_area.SetActive(true);
                }
            }
        }
        if (battleManager4 != null)
        {
            t_battle_manager_4 = battleManager4.GetComponent<TAMIYANOMAR_battle_manager>();
            if (t_battle_manager_4.getBattleClear() == true && battleFigure == 4)
            {
                questClear = true;
                if (gate != null)
                {
                    gate.GetComponent<TAMIYANOMAR_gete_manager>().gateDelete();
                }
            }
        }
        if (battleManager5 != null)
        {
            t_battle_manager_5 = battleManager5.GetComponent<TAMIYANOMAR_battle_manager>();
            if (t_battle_manager_5.getBattleClear() == true)
            {
                battleManager5.SetActive(false);
                questClear = true;
            }
        }
        
        

        if (battleManager1 != null)
        {
            
            if (questActive == true && t_battle_manager_1.activated() == false && firstActive1 == false)
            {
                //Debug.Log("setactive 1");
                battleManager1.SetActive(true);
                t_battle_manager_1.setActive();
                firstActive1 = true;
            }
        }

        if (battleManager2 != null)
        {
            
            if (t_battle_manager_1.getBattleClear() == true && t_battle_manager_2.activated() == false && firstActive2 == false)
            {
                Debug.Log("setactive 2");
                battleManager1.SetActive(false);
                battleManager2.SetActive(true);
                t_battle_manager_2.setActive();
                firstActive2 = true;
            }
        }

        if (battleManager3 != null)
        {
            
            if (t_battle_manager_2.getBattleClear() == true && t_battle_manager_3.activated() == false && firstActive3 == false)
            {
                Debug.Log("setactive 3");
                battleManager2.SetActive(false);
                battleManager3.SetActive(true);
                t_battle_manager_3.setActive();
                firstActive3 = true;
            }
        }

        if (battleManager4 != null)
        {
            
            if (t_battle_manager_3.getBattleClear() == true && t_battle_manager_4.activated() == false && firstActive4 == false)
            {
                battleManager3.SetActive(false);
                battleManager4.SetActive(true);
                t_battle_manager_4.setActive();
                firstActive4 = true;
            }
        }

        if (battleManager5 != null)
        {
            
            if (t_battle_manager_4.getBattleClear() == true && t_battle_manager_5.activated() == false && firstActive5 == false)
            {
                battleManager4.SetActive(false);
                battleManager5.SetActive(true);
                t_battle_manager_5.setActive();
                firstActive5 = true;
            }
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
