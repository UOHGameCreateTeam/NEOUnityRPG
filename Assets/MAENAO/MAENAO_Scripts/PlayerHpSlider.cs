using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpSlider : MonoBehaviour
{

    [SerializeField] private GameObject playerObj;
    [SerializeField] public Slider redSlider;
    [SerializeField] public Slider greenSlider;

    public bool gameOver = false;
    private int maxPlayerHp;
    private int currentPlayerHp;
    private tkp_player_tkp playerClass;



    // Start is called before the first frame update
    void Start()
    {
        playerClass = playerObj.GetComponent<tkp_player_tkp>();
        maxPlayerHp = playerClass.get_hp();
        greenSlider.value = 1;
        redSlider.value = 1;
        //Debug.Log("Start current HP" + maxPlayerHp);
    }



    // Update is called once per frame
    void Update()
    {
        currentPlayerHp = playerClass.get_hp();

        greenSlider.value = currentPlayerHp / maxPlayerHp;
        StartCoroutine(ResetRedSlider());

        if (currentPlayerHp <= 0)
        {
            gameOver = true;
        }
    }





    private IEnumerator ResetRedSlider()
    {
        yield return new WaitForSeconds(1);
        redSlider.value = currentPlayerHp / maxPlayerHp;
    }
}
