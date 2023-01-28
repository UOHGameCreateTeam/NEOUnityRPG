using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_weapon_dmg : MonoBehaviour
{
    //重なり判定用の変数
    private bool weapon_hit = false;
    //プレーヤーが与えるダメージ
    public int player_weapon_dmg = 10;
    //敵のクラスを読み込む
    private GameObject gameobject_enemy_hp;
    private SS_enemy_hp enemy_hp;
    //[SerializeField] private int player_weapon_dmg = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameobject_enemy_hp = GameObject.Find("Enemy");
        enemy_hp = gameobject_enemy_hp.GetComponent<SS_enemy_hp>();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレイヤーの武器と敵との重なり判定
    private void OnTriggerEnter(Collider other)
    {
        //取得した敵のhpを格納する変数
        int now_enemy_hp, tmp_enemy_hp;

        if (other.gameObject.name == "Enemy")
        {
            //敵hpの取得
            now_enemy_hp = enemy_hp.getHp();
            tmp_enemy_hp = now_enemy_hp - player_weapon_dmg;
            //ダメージの付与
            enemy_hp.setHp(tmp_enemy_hp);

            Debug.Log("hit_enemy");
            Debug.Log(enemy_hp.getHp());
            weapon_hit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Debug.Log("miss");
            weapon_hit = false;
        }
    }
}

