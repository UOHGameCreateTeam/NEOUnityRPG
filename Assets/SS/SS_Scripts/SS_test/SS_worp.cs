using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_worp : MonoBehaviour
{
    //private Transform tf;
    // Start is called before the first frame update
    private Vector3 ichi;
    [SerializeField]
    private GameObject serach;
    [SerializeField]
    private float followRate = 0f;
    [SerializeField]
    private float x_max_limit = 1000f;
    [SerializeField]
    private float x_min_limit = -1000f;
    [SerializeField]
    private float z_max_limit = 1000f;
    [SerializeField]
    private float z_min_limit = -1000f;
    //追尾するポイントのプレイヤーからの距離(つまり小さい程、近付く)。
    [SerializeField]
    private float followTargetDistance = 5.0f;
    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.up;
    private float time = 0f;
    [SerializeField] private float intarval = 8f;
    [SerializeField] private float limit_intarval = 16f;
    void Update()
    {
        time += Time.deltaTime;
        GameObject player = GameObject.FindWithTag("test_cube_1");
        //プレイヤーを一定の距離で追尾。
        if (time >= intarval)
        {
            if (time >= limit_intarval)
            {
                time = 0;
            }
        }
        else {
            ichi = Vector3.Lerp(this.transform.position, player.transform.position + (this.transform.position - player.transform.position).normalized * followTargetDistance, followRate);
            if (x_min_limit >= ichi.x) {
                ichi.x = x_min_limit;
            }
            if (x_max_limit <= ichi.x)
            {
                ichi.x = x_max_limit;
            }
            if (z_min_limit >= ichi.z)
            {
                ichi.z = z_min_limit;
            }
            if (z_max_limit <= ichi.z)
            {
                ichi.z = z_max_limit;
            }
            if (2 >= serach.transform.position.y)
            {
                ichi.y = 5;
            }
            this.transform.position = ichi;
        }

        
    }
    public void worp() {
        GameObject player = GameObject.FindWithTag("test_cube_1");
        float x1 = 0;
        float z1 = 0;
        int count1 = 0;
        int count2 = 0;
        serach.transform.position = this.transform.position;
        serach.transform.RotateAround(player.transform.position, RotateAxis, 120.0f);
        if (x_min_limit >= serach.transform.position.x)
        {
            x1 = x_min_limit;
            count1 = 1;
        }
        if (x_max_limit <= serach.transform.position.x)
        {
            x1 = x_max_limit;
            count1 = 1;
        }

        if (z_min_limit >= serach.transform.position.z)
        {
            z1 = z_min_limit;
            count2 = 1;
        }
        if (z_max_limit <= serach.transform.position.z)
        {
            count2 = 1;
        }

        if (count1 == 1 && count2 == 0)
        {
            serach.transform.position = new Vector3(x1, serach.transform.position.y, serach.transform.position.z);
        }
        else if (count1 == 1 && count2 == 1)
        {
            serach.transform.position = new Vector3(x1, serach.transform.position.y, z1);
        }
        else if (count1 == 0 && count2 == 1)
        {
            serach.transform.position = new Vector3(serach.transform.position.x, serach.transform.position.y, z1);
        }
        else { }

        if (2 >= serach.transform.position.y) {
            serach.transform.position = new Vector3(serach.transform.position.x, 5, serach.transform.position.z);
        }
        this.transform.position = serach.transform.position;
        //this.transform.RotateAround(player.transform.position, RotateAxis, 120.0f);

    }
   
}
