using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_test_beem : MonoBehaviour
{
   
    
    private GameObject p_end;
    private GameObject p_start;
    Vector3 vv;
    [SerializeField]
    private GameObject prefab1;
    [SerializeField]
    private GameObject prefab2;

    [SerializeField]
    private int laser_count;

    Vector3 dir;
    public void LaserBeam() 
    {
        p_end = Instantiate(prefab1, vv, Quaternion.identity);
        p_start = Instantiate(prefab2, vv, Quaternion.identity);
        dir = (p_end.transform.forward).normalized;
        p_end.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

        switch (laser_count)
        {
            case 1:
                p_end.transform.position = Vector3.Lerp(p_end.transform.position, transform.position + dir * 40.0f + new Vector3(0.0f, targetTransform.position.y + transform.up.y, 0.0f), 0.1f);
                break;
            case 2:
                p_start.transform.position = Vector3.Lerp(p_start.transform.position, p_end.transform.position - dir * 0.5f, 0.05f);
                break;
        }
    }

    public void LaserTrigger()
    {
        switch (laser_count)
        {
            case 0:
                laser_count++;
                break;
            case 1:
                laser_count++;
                break;
            case 2:
                p_end.transform.localPosition = Vector3.zero;
                p_start.transform.localPosition = new Vector3(0f, 0f, 0f);

                laser_count = 0;
                break;
        }
    }

    /*
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject prefab;
    */
    [SerializeField]
    private GameObject ha;
    

    private Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = ha.transform;
        laser_count = 0;
        vv = this.transform.position;
        vv.y += 5.0f;
    }
    /*
    public void LaserBullet()
    { 
        var dir = (targetTransform.position - transform.position).normalized;
        GameObject bullet = Instantiate(prefab, point.transform.position, transform.rotation);
        bullet.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        bullet.GetComponent<Rigidbody>().AddForce(dir * 100f, ForceMode.Impulse);
    }
    */
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
