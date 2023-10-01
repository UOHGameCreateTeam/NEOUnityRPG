using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tkp_player_walk_anim : MonoBehaviour
{
    private Animator animators;
    private bool walk_flag;
    private string input_key;
    // Start is called before the first frame update
    void Start()
    {
        animators = this.gameObject.GetComponent<Animator>();
        walk_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(code))
                {
                    // ���͂��ꂽ�L�[����\��
                    input_key = code.ToString();

                    //���͂ɉ����ĉ�������
                    if (input_key == "W") walk_flag = true;
                    // else walk_flag = false;
                    if (input_key == "A") walk_flag = true;
                    // else walk_flag = false;
                    if (input_key == "S") walk_flag = true;
                    // else walk_flag = false;
                    if (input_key == "D") walk_flag = true;
                    // else walk_flag = false;

                }

            }
        }
        else
        {
            walk_flag = false;

        }
        animators.SetBool("Run", walk_flag);
        Debug.Log(walk_flag);
    }  
}
