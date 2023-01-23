using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_pre_manager : MonoBehaviour
{
    [SerializeField] GameObject playerObj;

    private bool activated = false;
    private bool arrived = false;
    private Vector2 destination;


    private void Start()
    {
        activated = false;
        arrived = false;
    }

    void Update()
    {
        if(activated == true)
        {
            float gap_x = Mathf.Abs(playerObj.transform.position.x - destination.x);
            float gap_z = Mathf.Abs(playerObj.transform.position.z - destination.y);


            if(gap_x < 10f && gap_z < 10f)
            {
                Debug.Log("arrived true");
                arrived = true;
                activated = false;
                TAMIYANOMAR_destination_manager destination_Manager = this.gameObject.GetComponent<TAMIYANOMAR_destination_manager>();
                destination_Manager.deactivateDestination();
            }
        }
    }

    public void setActive(Vector2 dest)
    {
        Debug.Log("activate dest");
        activated = true;
        destination = dest;
        arrived = false;
        TAMIYANOMAR_destination_manager destination_Manager =  this.gameObject.GetComponent<TAMIYANOMAR_destination_manager>();
        destination_Manager.activateDestination(dest);
    }

    public bool getArrived()
    {
        return arrived;
    }


    //not needed
    public Vector3 getDestination()
    {
        return new Vector3(destination.x, 0f, destination.y);
    }
}
