using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horming2 : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    Vector3 moveSpeed = new Vector3(0f, 0f, 0f);
    float accSpeed = 3.0f;
    float maxSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position
                                                        - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                 targetRotation, 120f * Time.deltaTime);
        moveSpeed += transform.rotation * Vector3.forward * accSpeed * Time.deltaTime;
        if (moveSpeed.magnitude >= maxSpeed)
        {
            moveSpeed = moveSpeed.normalized * maxSpeed;
        }
    }
}
