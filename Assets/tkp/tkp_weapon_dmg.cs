using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_weapon_dmg : MonoBehaviour
{
    //�d�Ȃ蔻��p�̕ϐ�
    private bool weapon_hit = false;
    //�v���[���[���^����_���[�W
    public int player_weapon_dmg = 10;
    //�G�̃N���X��ǂݍ���
    private GameObject gameobject_enemy_hp;
    private SS_enemy_hp enemy_hp;
    //[SerializeField] private int player_weapon_dmg = 10;
    // Start is called before the first frame update
    void Start()
    {
        //gameobject_enemy_hp = GameObject.Find("Enemy");
        //if (gameobject_enemy_hp != null) enemy_hp = gameobject_enemy_hp.GetComponent<SS_enemy_hp>();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�v���C���[�̕���ƓG�Ƃ̏d�Ȃ蔻��


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("A");
        //�擾�����G��hp���i�[����ϐ�
        int now_enemy_hp, tmp_enemy_hp;
        
        if (other.gameObject.tag == "Enemy")
        {
            enemy_hp = other.gameObject.GetComponent<SS_enemy_hp>();
            //�Ghp�̎擾
            now_enemy_hp = enemy_hp.getHp();
            tmp_enemy_hp = now_enemy_hp - player_weapon_dmg;
            //�_���[�W�̕t�^
            enemy_hp.setHp(tmp_enemy_hp);

            Debug.Log("hit_enemy");
            Debug.Log(enemy_hp.getHp());
            weapon_hit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Enemy")
        {
            weapon_hit = false;
        }
    }
}

