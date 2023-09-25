using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_dmg_area : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject dmg_area_obj;
    private Rigidbody rb;

    void Start()
    {
        float rand_x = Random.Range(1.0f,10.0f);
        float rand_y = Random.Range(20.0f,40.0f);
        float rand_z = Random.Range(1.0f,10.0f);
        Vector3 add_force = new Vector3(1,30,0);

        dmg_area_obj = this.gameObject;
        rb = GetComponent<Rigidbody>();
        rb.velocity = add_force;

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Destroy(dmg_area_obj, 20.5f);
    }
}
