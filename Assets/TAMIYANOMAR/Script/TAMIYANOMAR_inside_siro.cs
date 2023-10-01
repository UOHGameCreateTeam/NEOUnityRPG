using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_inside_siro : MonoBehaviour
{
    private bool inside = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "test_cube_1")
        {
            inside = true;
            //Debug.Log("inside");
        }
    }

    public bool get_inside_or_not()
    {
        return inside;
    }
}
