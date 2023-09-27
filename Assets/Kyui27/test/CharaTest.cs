using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaTest : MonoBehaviour
{
    //AudioClip型の変数を設定。使用する音源の数だけ用意する。全部public
    //SE関連
    public AudioClip SE1;
    public AudioClip SE2;
    public AudioClip SE3;
    public AudioClip SE4;
    //BGM関連
    public AudioClip BGM1;
    public AudioClip BGM2;
    public AudioClip Intro1;
    public AudioClip Intro2;

    public int BGMnum=0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //SEの方。SEを流したい箇所に以下のif文を追加するだけ

        //上入力時SE1を流す
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //SoundMasterのPlaySE()に音源データを渡す.
            SoundMaster.instance.PlaySE(SE1);
            //SoundMasterのPlaySE()に音源データを渡す.
            //PlaySE()は渡された音源を流すメソッド
        }
        //下入力時SE2を流す
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            SoundMaster.instance.PlaySE(SE2);
        }
        //右入力時SE3を流す
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            SoundMaster.instance.PlaySE(SE3);
        }
        //左入力時SE4を流す
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            SoundMaster.instance.PlaySE(SE4);
        }

        //BGMの方。BGMを流したい箇所に以下のif文を追加するだけ
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            //[書き方]SoundMaster.instance.PlayBGM(AudioClip型のループ楽曲,AudioClip型のイントロ楽曲,int数字※0以外かつ他のBGMと被らなければなんでも)
            SoundMaster.instance.PlayBGM(BGM1,Intro1,BGMnum=1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SoundMaster.instance.PlayBGM(BGM2,Intro2,BGMnum=2);
        }

        //BGMのVolumeを変更
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            //[書き方]SoundMaster.instance.VolBGM(float 変更したい音量)
            SoundMaster.instance.VolBGM(0.2f);
            //音量の変更範囲は、0.0f(0%)～1.0f(100%)まで
        }

        //BGMを停止
        if(Input.GetKeyDown(KeyCode.Space)){
            //[書き方]SoundMaster.instance.StopBGM()
            SoundMaster.instance.StopBGM();
        }
    }
    void FixedUpdate()
    {
        SoundMaster.instance.UpdateFootSound();
    }
}