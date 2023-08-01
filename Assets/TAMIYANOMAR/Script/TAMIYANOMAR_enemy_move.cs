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

    private bool pose = false;
    private float poseTime = 1.2f;
    private float timer = 0f;
    private bool warpFlag = false;
    private int behavenum = 0;
    private bool lookAtFlag = false;
    private float lookAtTime = 1f;
    private Vector3 nextPosition;


    void Update()
    {
        toRotation.transform.LookAt(player.transform);
        if (pose)
        {
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
            //Vector3 rotation = toRotation.transform.rotation.eulerAngles - this.transform.rotation.eulerAngles;
            //this.transform.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x + rotation.x * Time.deltaTime / lookAtTime, this.transform.rotation.eulerAngles.y + rotation.y * Time.deltaTime / lookAtTime, this.transform.rotation.eulerAngles.z + rotation.z * Time.deltaTime / lookAtTime);
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
        pose = true;
        Instantiate(bullet, muzzle.transform.position, this.transform.rotation);
    }

    void warp()
    {
        pose = true;
        warpFlag = true;
        warpParticle.Play();
        nextPosition = this.transform.position + this.transform.forward * 10f + transform.right * 10f;
    }
}
