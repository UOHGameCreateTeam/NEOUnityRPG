using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_stage_manager : MonoBehaviour
{
    [SerializeField] private GameObject questManager1;
    [SerializeField] private GameObject questManager2;
    [SerializeField] private GameObject questManager3;
    [SerializeField] private string stageName;
    [SerializeField] private GameObject SoundManager;

    private bool stageClear = false;

    private bool quest1 = false;
    private bool quest2 = false;
    private bool quest3 = false;

    private bool stageActive = false;


    private void Start()
    {
        //Music Start
    }

    void Update()
    {
        TAMIYANOMAR_quest_manager t_quest_manager_1 = questManager1.GetComponent<TAMIYANOMAR_quest_manager>();
        TAMIYANOMAR_quest_manager t_quest_manager_2 = questManager2.GetComponent<TAMIYANOMAR_quest_manager>();
        TAMIYANOMAR_quest_manager t_quest_manager_3 = questManager3.GetComponent<TAMIYANOMAR_quest_manager>();

        if (stageActive == true &&quest1 ==false )
        {  
            t_quest_manager_1.setActive();
            quest1 = true;
        }

        if (t_quest_manager_1.getQuestClear() == true && quest2 == false)
        {
            t_quest_manager_2.setActive();
            quest2 = true;
        }

        if (t_quest_manager_2.getQuestClear() == true && quest3 == false)
        {
            t_quest_manager_3.setActive();
            quest3 = true;
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
