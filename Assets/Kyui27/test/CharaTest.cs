using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaTest : MonoBehaviour
{
    //AudioClip型の変数を設定。使用する音源の数だけ用意する
    public AudioClip SE1;
    public AudioClip SE2;
    public AudioClip SE3;
    public AudioClip SE4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //上入力
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            SoundMaster.instance.PlaySE(SE1);
        }
        //下入力
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            SoundMaster.instance.PlaySE(SE2);
        }
        //右入力
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            SoundMaster.instance.PlaySE(SE3);
        }
        //左入力
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            SoundMaster.instance.PlaySE(SE4);
        }
    }
}
