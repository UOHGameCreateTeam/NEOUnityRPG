using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_enemy2_move : MonoBehaviour
{
    [SerializeField] GameObject attack_cube;
    [SerializeField] GameObject rush_cube;
    [SerializeField] GameObject player;
    [SerializeField] GameObject toRotation;

    private float lookAtTime = 2.0f;
    private float AttackTime = 3.0f;
    private float RushTime = 2.0f;
    private float IdleTime = 0.8f;
    private bool RushOrAttack = false;

    private float timer = 0f;

    private int moveFlag = 0;
    private int LookAtFlag = 1;
    private int AttackFlag = 2;
    private int IdleFlag = 0;

    private float RushSpeed = 70f;
    private float near = 40f;

    private SS_enemy_hp ss_hp;
    private int hp = 100;
    private int former_hp = 100;

    private void Start()
    {
        ss_hp = this.gameObject.GetComponent<SS_enemy_hp>();
    }

    void Update()
    {
        hp = ss_hp.getHp();
        if(hp < former_hp)
        {
            Debug.Log("Enemy2 got damage");
            moveFlag = IdleFlag;
        }
        former_hp = hp;
        
        toRotation.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
        toRotation.transform.LookAt(player.transform);
        float distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (moveFlag == IdleFlag)
        {
            timer += Time.deltaTime;
            if (timer > IdleTime)
            {
                timer = 0f;
                moveFlag = LookAtFlag;
            }
           
        }

        if (moveFlag == LookAtFlag)
        {
            Quaternion rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation.transform.rotation, 300f * Time.deltaTime);
            this.transform.rotation = rotation;
            timer += Time.deltaTime;
            if (lookAtTime < timer)
            {
                timer = 0f;
                moveFlag = AttackFlag;
                if (distance < near)
                {
                    RushOrAttack = true;
                }
                else
                {
                    RushOrAttack = false;
                }
            }

        }

        if (moveFlag == AttackFlag)
        {
            timer += Time.deltaTime;

            if (RushOrAttack == true)
            {
                Quaternion rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation.transform.rotation, 3f * Time.deltaTime);
                this.transform.rotation = rotation;
                if (timer > AttackTime)
                {
                    timer = 0f;
                    moveFlag = IdleFlag;
                    attack_cube.SetActive(false);
                    return;
                }
                if(timer > AttackTime * 0.2f)
                {
                    attack_cube.SetActive(true);
                }

            }
            else
            {
                rush_cube.SetActive(true);
                if (timer > RushTime || distance < 14f)
                {
                    timer = 0f;
                    moveFlag = IdleFlag;
                    rush_cube.SetActive(false);
                    return;
                }
                
                Quaternion rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation.transform.rotation, 20f * Time.deltaTime);
                this.transform.rotation = rotation;
                transform.position += transform.forward * RushSpeed * Time.deltaTime;
            }
        }

    }

    public void gaveDamage()
    {
        timer = 0f;
        moveFlag = IdleFlag;
        rush_cube.SetActive(false);
        return;
    }

}
