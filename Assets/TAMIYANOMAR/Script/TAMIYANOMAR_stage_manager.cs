using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_stage_manager : MonoBehaviour
{
    [SerializeField] private GameObject questManager1;
    [SerializeField] private GameObject questManager2;
    [SerializeField] private GameObject questManager3;

    private bool stageClear = false;

    private bool stageActive = false;
    void Update()
    {
        TAMIYANOMAR_quest_manager t_quest_manager_1 = questManager1.GetComponent<TAMIYANOMAR_quest_manager>();
        TAMIYANOMAR_quest_manager t_quest_manager_2 = questManager2.GetComponent<TAMIYANOMAR_quest_manager>();
        TAMIYANOMAR_quest_manager t_quest_manager_3 = questManager2.GetComponent<TAMIYANOMAR_quest_manager>();

        if (stageActive == true)
        {  
            t_quest_manager_1.setActive(); 
        }

        if (t_quest_manager_1.getQuestClear() == true)
        {
            t_quest_manager_2.setActive();
        }

        if (t_quest_manager_2.getQuestClear() == true)
        {
            t_quest_manager_3.setActive();
        }

        if (t_quest_manager_3.getQuestClear() == true)
        {
            stageClear = true;
        }

    }

    public bool getStageClear()
    {
        return stageClear;
    }

    public void setStageActive()
    {
        stageActive = true;
    }
}
