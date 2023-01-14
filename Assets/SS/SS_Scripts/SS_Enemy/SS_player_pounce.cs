using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_player_pounce : MonoBehaviour
{
    private GameObject target;
    private float timer_pass = 0;
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float timer = 3f;
    void Start()
    {
        target = GameObject.Find("Player");
        transform.LookAt(target.transform);
    }

    void Update()
    {
        timer_pass += Time.deltaTime;
        
        if (timer_pass >= timer)
        {
            transform.position += transform.forward * Speed;
            float dis = Vector3.Distance(target.transform.position, transform.position);
            Debug.Log(dis);
            if (dis <= 2)
            {
                transform.position = target.transform.position;
                this.GetComponent<SS_player_pounce>().enabled = false;
            }
        }
        
    }

}
