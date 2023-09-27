using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_player_tkp : MonoBehaviour
{
    [SerializeField] private int hp;
    private GameObject camera_obj;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        camera_obj = GameObject.Find("Main Camera");
        // Debug.Log(this.gameObject.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.forward = camera_obj.transform.forward;
        // Debug.Log(this.gameObject.transform.forward);
    }
    //hp�Ǘ��p�֐�
    //get_hp()�@hp�擾
    public int get_hp()
    {
        return hp;
    }
    //set_hp() hp��������
    public void set_hp(int set_values)
    {
        hp = set_values;
    }

}
