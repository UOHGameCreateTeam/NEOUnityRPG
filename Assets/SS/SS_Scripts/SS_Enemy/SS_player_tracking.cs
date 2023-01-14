using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_player_tracking : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float Speed = 0.1f;

    void Start()
    {
        target = GameObject.Find("Player");
    }

    void Update()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * Speed;
    }
    public void setSpeed(float setValue)
    {
        Speed = setValue;
    }
    public float getSpeed()
    {
        return Speed;
    }
}
