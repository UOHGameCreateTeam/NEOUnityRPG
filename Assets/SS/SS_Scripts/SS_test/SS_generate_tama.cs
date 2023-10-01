using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_generate_tama : MonoBehaviour
{
    private float time = 0f;
    [SerializeField] float interbal = 1f;
    [SerializeField] GameObject prefab;
    [SerializeField] float speeddd = 5f;//飛ばすときの初速度
    [SerializeField] float maxSpeedY = 10f;//飛ばすときのY方向の最高速度(大きいほど角度が大きくなる)

    Vector3 vv;
    void Start()
    {
        
    }

    public void hassha() {
        SoundManager.Instance.PlaySE(SESoundData.SE.mahou, SourceData.Source.mahoutu);
        vv = this.transform.position;
        vv.y += 5.0f;
        
        GameObject tama = Instantiate(prefab, vv, Quaternion.identity);
        Vector3 vel = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * speeddd;
        vel.y = maxSpeedY;
        //射出
        Rigidbody rid = tama.GetComponent<Rigidbody>();
        rid.velocity = vel;
        Destroy(tama, 5f);

    }
    
}
