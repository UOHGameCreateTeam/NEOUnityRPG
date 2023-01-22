using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_enemy_gravity : MonoBehaviour
{
    private Vector3 Enemy_gravity;
    [SerializeField] private float gravity_power = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Enemy_gravity = new Vector3(0, -gravity_power, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_gravity = new Vector3(0, -gravity_power, 0);
        Vector3 g;
        g = Enemy_gravity * Time.deltaTime;
        transform.Translate(0f, g.y * Time.deltaTime, 0f);
        if (transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (this.GetComponent<SS_enemy_gravity>().enabled == true)
        {
            Debug.Log("“–‚½‚Á‚½‚æ");
            if (collision.gameObject.tag == "ground")
            {
                Enemy_gravity.y = 0;
            }
        }

    }
}
