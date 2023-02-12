using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_destination_rotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y + rotateSpeed * Time.deltaTime, this.gameObject.transform.eulerAngles.z);
    }
}
