using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHpSlider : MonoBehaviour
{

    [SerializeField] private GameObject playerObj;
    [SerializeField] public Slider redSlider;
    [SerializeField] public Slider greenSlider;
    [SerializeField] public Slider warningSlider;
    [SerializeField] public Animator anim;

    public bool gameOver = false;
    private int maxPlayerHp;
    private int currentPlayerHp;
    private int getPlayerHp;
    private int damage;
    private MAENAO_tkp_player_tkp playerClass;



    // Start is called before the first frame update
    void Start()
    {
        playerClass = playerObj.GetComponent<MAENAO_tkp_player_tkp>();
        anim = gameObject.GetComponent<Animator>();
        //maxPlayerHp = playerClass.get_hp();
        currentPlayerHp = playerClass.get_hp();
        maxPlayerHp = currentPlayerHp;
        getPlayerHp = currentPlayerHp;
        damage = 0;
        greenSlider.value = 1;
        redSlider.value = 1;
        warningSlider.value = 0;
        //Debug.Log("Start current HP" + maxPlayerHp);
    }



    // Update is called once per frame
    void Update()
    {
        //currentPlayerHp = playerClass.get_hp();
        if (Input.GetKey(KeyCode.Return))
        {
            getPlayerHp = currentPlayerHp - 2;
        }
        
        //getPlayerHp = playerClass.get_hp(); // 
        if (currentPlayerHp - getPlayerHp > 0)
        {
            damage = currentPlayerHp - getPlayerHp;
            currentPlayerHp = getPlayerHp;
        }

        greenSlider.value = (float)currentPlayerHp / (float)maxPlayerHp;
        if (damage > 0)
        {
            StartCoroutine(ResetRedSlider());
            damage = 0;
        }
        
        

        if (currentPlayerHp <= maxPlayerHp * 0.05f)
        {
            warningSlider.value = 1;
            anim.SetBool("boolwarning", true);
        }

        if (currentPlayerHp <= 0)
        {
            gameOver = true;
            SceneManager.LoadScene("GameoverScene");
        }
    }



    private IEnumerator ResetRedSlider()
    {
        yield return new WaitForSeconds(1.0f);
        redSlider.value = (float)currentPlayerHp / (float)maxPlayerHp;
        yield break;

    }
}
