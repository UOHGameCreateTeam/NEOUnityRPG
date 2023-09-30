using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_fit_sphere_collider : MonoBehaviour
{
    private GameObject wave_obj;
    private SphereCollider collider;
    public float init_sphere_radius = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        collider.radius = init_sphere_radius;
    }

    // Update is called once per frame
    void Update()
    {
        // collider.radius = init_sphere_radius * this.gameObject.GetComponent<tkp_blow_wave>().Get_Radius();   

        // Debug.Log(collider.radius);
    }
}
