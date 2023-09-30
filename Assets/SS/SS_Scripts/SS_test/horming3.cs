using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horming3 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotateSpeed = 6000000000f;
    [SerializeField] private float rotateSpeed_ac = 1;
  
    private GameObject player;
    [SerializeField] private GameObject toRotation;


    Vector3 vvv;
    private float time = 0;

    void faa()
    {
        Vector3 vel_za = new Vector3(0, 0, 0);
        //Debug.Log("a");
        
            GetComponent<Rigidbody>().velocity = vel_za;

            if (player != null)
            {
                this.transform.LookAt(player.transform.position);
                //Quaternion rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation.transform.rotation, rotateSpeed * Time.deltaTime);

                //this.transform.rotation = rotation;

                //rotateSpeed += rotateSpeed_ac;
            }
            GetComponent<Rigidbody>().AddForce(transform.forward * 2000, ForceMode.Force);



    }
    void Start()
    {
        player = GameObject.FindWithTag("test_cube_1");
        Invoke("faa", 1f);
    }

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("faefa");
        if (collision.gameObject.tag == "test_cube_1")
        {
            Destroy(this);
        }
    }

}
