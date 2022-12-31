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

    private void Start()
    {
        battlePosition = new Vector2(battleDestination.transform.position.x, battleDestination.transform.position.z);
    }

    void Update()
    {
        if(battleActive == true)
        {
            TAMIYANOMAR_pre_manager t_pre_Manager = preManager.GetComponent<TAMIYANOMAR_pre_manager>();
            t_pre_Manager.setActive(battlePosition);
        }

        if(battleStart == true)
        {
            Enemy_1.SetActive(true);
            Enemy_2.SetActive(true);
            Enemy_3.SetActive(true);
        }

        //バトルクリアの判定

    }

    public bool getBattleClear()
    {
        return battleClear;
    }

    public void setActive()
    {
        battleActive = true;
    }    
}
