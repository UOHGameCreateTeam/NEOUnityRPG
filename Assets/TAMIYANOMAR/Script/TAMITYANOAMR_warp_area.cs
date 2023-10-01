using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMITYANOAMR_warp_area : MonoBehaviour
{
    [SerializeField] Transform player_rans;
    [SerializeField] Transform warp_trans; 
    void Update()
    {
        float distance = Vector3.Distance(player_rans.position, this.gameObject.transform.position);
        if(distance <= 5)
        {
            player_rans.position = warp_trans.position;
            this.gameObject.SetActive(false);
        }
    }
}
