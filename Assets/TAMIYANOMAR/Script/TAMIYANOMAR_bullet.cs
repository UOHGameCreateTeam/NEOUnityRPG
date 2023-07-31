using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotateSpeed = 6000000000f;

    private GameObject player;
    [SerializeField] private GameObject toRotation;

    void Start()
    {
        player = GameObject.FindWithTag("test_cube_1");
        Debug.Log(player.name);
    }

    void Update()
    {
        if (player != null)
        {
            toRotation.transform.LookAt(player.transform.position);
            Quaternion rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation.transform.rotation, rotateSpeed * Time.deltaTime);
            this.transform.rotation = rotation;
        }
        transform.position += transform.forward * Time.deltaTime * speed - transform.up * Time.deltaTime * 0.1f;
        
    }
}
