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
    public AudioClip BGM1;
    public AudioClip BGM2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SEの方
        //再生条件(上入力)
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //SoundMasterのPlaySE()に音源データを渡す.
            //PlaySE()はSoundMaster内にある渡された音源を流すメソッド
            //[書き方]SoundMaster.instance.PlaySE(AudioClip型の音源データ)
            SoundMaster.instance.PlaySE(SE1);
        }
        //下入力時SE2をPlaySEに渡す
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            SoundMaster.instance.PlaySE(SE2);
        }
        //右入力時SE3をPlaySEに渡す
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            SoundMaster.instance.PlaySE(SE3);
        }
        //左入力時SE4をPlaySEに渡す
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            SoundMaster.instance.PlaySE(SE4);
        }

        //BGMの方
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SoundMaster.instance.PlayBGM(BGM1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SoundMaster.instance.PlayBGM(BGM2);
        }

    }
}
