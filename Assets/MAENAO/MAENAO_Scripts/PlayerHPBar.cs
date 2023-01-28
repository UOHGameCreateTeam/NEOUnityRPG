using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHPBar : MonoBehaviour
{
    //[SerializeField] private Image GreenGage;
    
    [SerializeField] private GameObject playerObj;
    [SerializeField] public Slider slider;

    public bool gameOver = false;
    private int maxPlayerHp;
    private int currentPlayerHp;
    private tkp_player_tkp playerClass;



    // Start is called before the first frame update
    void Start()
    {
        playerClass = playerObj.GetComponent<tkp_player_tkp>();
        maxPlayerHp = playerClass.get_hp();
        slider.value = 1;
        Debug.Log("Start current HP" + maxPlayerHp);
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerHp = playerClass.get_hp();

        slider.value = currentPlayerHp / maxPlayerHp;

        if (currentPlayerHp <= 0)
        {
            gameOver = true;
        }

        
        

        
    }

}
