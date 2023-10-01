using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_enemy_move : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject toRotation;
    [SerializeField] GameObject muzzle;
    [SerializeField] ParticleSystem warpParticle;
    [SerializeField] Animator EnemyAnimator;
    [SerializeField] SS_enemy_hp enemy_hp;
    private bool pose = false;
    private float poseTime = 1.2f;
    private float timer = 0f;
    private bool warpFlag = false;
    private int behavenum = 0;
    private bool lookAtFlag = false;
    private float lookAtTime = 1f;
    private Vector3 nextPosition;
    private int former_hp = 100;
    private int max_x;
    private int min_x;
    private int max_z;
    private int min_z;


    private void Start()
    {
        max_x = (int)(this.transform.position.x + 40f);
        min_x = (int)(this.transform.position.x - 40f);
        max_z = (int)(this.transform.position.z + 40f);
        min_z = (int)(this.transform.position.z - 40f);
    }

    void Update()
    {
        EnemyAnimator.SetBool("Attack", false);
        EnemyAnimator.SetBool("Warp", false);
        toRotation.transform.LookAt(player.transform);
        if (pose)
        {
            int now_hp = enemy_hp.getHp();
            if (former_hp > now_hp)
            {
                poseTime = 2.0f;
                EnemyAnimator.speed = 0.7f;
                this.gameObject.transform.position -= new Vector3( (player.transform.position.x - this.transform.position.x) / Mathf.Abs(player.transform.position.x - this.transform.position.x) * 1.1f, 0, (player.transform.position.z - this.transform.position.z) / Mathf.Abs(player.transform.position.z - this.transform.position.z) * 1.1f);
            }
            former_hp = now_hp;
            timer += Time.deltaTime;
            if (timer > poseTime)
            {
                pose = false;
                poseTime = 1.2f;
                timer = 0f;
                behavenum += 1;
                if (behavenum == 4)
                {
                    behavenum = 0;
                }
            }
            return;
        }

        if (warpFlag)
        {
            this.gameObject.transform.position = nextPosition;
            warpParticle.Stop();
            warpFlag = false;
            return;
        }

        if (lookAtFlag)
        {
            Quaternion rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation.transform.rotation, 300f * Time.deltaTime);
            this.transform.rotation = rotation;
            timer += Time.deltaTime;
            if (lookAtTime < timer)
            {
                timer = 0f;
                lookAtFlag = false;
            }
            return;
            
        }

        switch (behavenum)
        {
            case 0:
                lookAtPlayer();
                break;
            case 1:
                warp();
                break;
            case 2:
                lookAtPlayer();
                break;
            case 3:
                shoot();
                break;
        }
    }

    void lookAtPlayer()
    {
        pose = true;
        lookAtFlag = true;
    }

    void shoot()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.wizard_shoot_ball, SourceData.Source.wizard);
        pose = true;
        Instantiate(bullet, muzzle.transform.position, this.transform.rotation);
        EnemyAnimator.SetBool("Attack", true);
    }

    void warp()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.wizard_warp, SourceData.Source.wizard);
        pose = true;
        warpFlag = true;
        warpParticle.Play();
        if (Random.Range(0f,1f) > 0.5)
        {
            nextPosition = this.transform.position + this.transform.forward * 15f + transform.right * 15f;
        }
        else
        {
            nextPosition = this.transform.position - this.transform.forward * 15f - transform.right * 15f;
        }
        if(nextPosition.x > max_x)
        {
            nextPosition.x = max_x;
        }
        if (nextPosition.x < min_x)
        {
            nextPosition.x = min_x;
        }
        if (nextPosition.z > max_z)
        {
            nextPosition.z = max_z;
        }
        if (nextPosition.z < min_z)
        {
            nextPosition.z = min_z;
        }
        EnemyAnimator.SetBool("Warp", true);
    }
}
