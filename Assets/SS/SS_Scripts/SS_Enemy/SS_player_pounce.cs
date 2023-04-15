using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_player_pounce : MonoBehaviour
{
    private GameObject target;
    private float timer_pass = 0;
    private bool sumon;
    private GameObject atari;
    private Vector3 distination_position;
    [SerializeField] private GameObject kinsetu;
    [SerializeField] private float Speed = 0.8f;
    [SerializeField] private float timer = 3f;
    void Start()
    {
        sumon = false;
        target = GameObject.Find("Player");
        transform.LookAt(target.transform);
        distination_position = target.transform.position;
        
    }

    void Update()
    {

        timer_pass += Time.deltaTime;
        
        if (timer_pass >= timer)
        {
            if (sumon == false)
            {
                //atari = Instantiate(kinsetu, this.transform.position, Quaternion.identity);
                sumon = true;
            }
            this.transform.position = this.transform.position;
            transform.position += transform.forward * Speed;
            float dis = Vector3.Distance(distination_position, transform.position);
   
            if (dis <= 2)
            {
                this.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
                Speed = 0;
                transform.position = new Vector3(distination_position.x, 3.5f,distination_position.z);
                this.GetComponent<SS_player_pounce>().enabled = false;
            }
        }
        
    }

}
