using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_generate_tama : MonoBehaviour
{
    private float time = 0f;
    [SerializeField] float interbal = 1f;
    [SerializeField] GameObject prefab;
    [SerializeField] float speeddd = 5f;//��΂��Ƃ��̏����x
    [SerializeField] float maxSpeedY = 10f;//��΂��Ƃ���Y�����̍ō����x(�傫���قǊp�x���傫���Ȃ�)

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
        //�ˏo
        Rigidbody rid = tama.GetComponent<Rigidbody>();
        rid.velocity = vel;
        Destroy(tama, 5f);

    }
    
}
