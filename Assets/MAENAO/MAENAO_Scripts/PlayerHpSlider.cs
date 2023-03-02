using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private int getPlayerHp = 100;
    private int damage;
    private tkp_player_tkp playerClass;



    // Start is called before the first frame update
    void Start()
    {
        playerClass = playerObj.GetComponent<tkp_player_tkp>();
        anim = gameObject.GetComponent<Animator>();
        //maxPlayerHp = playerClass.get_hp();
        maxPlayerHp = 100;
        currentPlayerHp = 100;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            getPlayerHp = currentPlayerHp - 2;
        }

        //getPlayerHp = playerClass.get_hp(); // ダメージ受けてHP減ったときの残りHP
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
        }
    }



    private IEnumerator ResetRedSlider()
    {
        yield return new WaitForSeconds(1.0f);
        redSlider.value = (float)currentPlayerHp / (float)maxPlayerHp;
        yield break;

    }
}
