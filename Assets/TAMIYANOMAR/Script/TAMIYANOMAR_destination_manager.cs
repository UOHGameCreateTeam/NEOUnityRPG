using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_destination_manager : MonoBehaviour
{
    [SerializeField] private GameObject destinationObj;
    
    
    public void activateDestination(Vector2 destination)
    {
        destinationObj.transform.position = new Vector3(destination.x, 0, destination.y);
        destinationObj.SetActive(true);
    }

    public void deactivateDestination()
    {
        destinationObj.SetActive(false);
    }

}
