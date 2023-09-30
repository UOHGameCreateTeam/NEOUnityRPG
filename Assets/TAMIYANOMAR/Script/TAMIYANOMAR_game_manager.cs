using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TAMIYANOMAR_game_manager : MonoBehaviour
{
    [SerializeField] private GameObject stageManager1;
    [SerializeField] private GameObject playerObj;

    private bool gameClear = false;
    private bool gameOver = false;

    private void Start()
    {
        TAMIYANOMAR_stage_manager t_stage_manager_1 = stageManager1.GetComponent<TAMIYANOMAR_stage_manager>();
        t_stage_manager_1.setStageActive();
    }

    void Update()
    {
        tkp_player_tkp player_class = playerObj.GetComponent<tkp_player_tkp>();
        int player_hp = player_class.get_hp();
        if(player_hp <= 0)
        {
            Debug.Log("game over");
            gameOver = true;
            SceneManager.LoadScene("GameoverScene");
        }

        
        TAMIYANOMAR_stage_manager t_stage_manager_1 =  stageManager1.GetComponent<TAMIYANOMAR_stage_manager>();
        if(t_stage_manager_1.getStageClear() == true)
        {
            gameClear = true;
            SceneManager.LoadScene("GameClearScene");
        }
    }

    public bool getGameClear()
    {
        return gameClear;
    }

    public bool getGameOver()
    {
        return gameOver;
    }

}
