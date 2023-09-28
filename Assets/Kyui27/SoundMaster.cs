using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    //変数準備
    public static SoundMaster instance = null;
    AudioSource audioSource = null;
    AudioSource BGM = null;
    AudioSource Intro = null;
    int flag = 0;
    //flagについて。今どのBGMを鳴らしているのかを判断。0は停止中。他は呼び出す際に任意に設定
    public AudioClip walk1;
    public AudioClip walk2;
    public AudioClip walk3;
    public AudioClip walk4;
    public AudioClip jump;
    int walkTimer_;
    int walkStride =25;

    private void Awake(){
        //よくわからん。多分おまじない
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //各種GetComponent
        audioSource = GetComponent<AudioSource>();
        BGM = GetComponent<AudioSource>();
        Intro = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //SE流すメソッド
    public void PlaySE(AudioClip clip)
    {
        if(clip != null){
            //引数が正しく与えられればPlayOneShot。重ね掛け可能
            audioSource.PlayOneShot(clip) ;
        }
    }

    //BGMを鳴らすメソッドに繋ぐ橋渡し.
    public void PlayBGM(AudioClip BGMData,AudioClip IntroData,int num){
        StartCoroutine(margeBGM(BGMData,IntroData,num));
    }


    //BGMを鳴らすメソッド.本当は直接こっちに持っていきたかったけど,なんか他のクラスだと動かないからやむなく。
    IEnumerator margeBGM(AudioClip BGMData,AudioClip IntroData,int num)
    {
        //イントロを流す
        flag = num;
        Debug.Log("BGM stop flag off");
        Intro.clip = IntroData;
        Intro.loop = false;
        Intro.volume = 1.0f;
        Intro.Play();
        
        //イントロの時間だけ待つ
        yield return new WaitForSeconds(IntroData.length);

        //ループを流す。条件は今流している曲と流そうとしている曲が同じものかを判定
        if(flag == num){
            BGM.clip = BGMData;
            BGM.loop = true;
            BGM.volume = 1.0f;
            BGM.Play() ;
        }
    }

    //BGM音量を指定値に調整するメソッド
    public void VolBGM(float vol)
    {
        BGM.volume = vol;
    }

    //BGMを停止
    public void StopBGM(){
        BGM.Stop();
        flag = 0;
        Debug.Log("BGM stop flag on");
    }

    public void UpdateFootSound()
    {
        //移動時、タイマーインクリメント　要、移動キー再設定
        if(Input.GetKey(KeyCode.Space))
        {
            audioSource.PlayOneShot(jump);
        }
        else if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.S))
        {
            ++walkTimer_;
        }
        else if(walkTimer_>=0)
        {
            Random.InitState(walkTimer_);
            walkTimer_=0;
        }
        if(walkTimer_ == 0)
        {
            return;
        }
        //一定間隔で足音を鳴らす。
        if(walkTimer_ == 2 || walkTimer_%walkStride ==0)
        {
            int tmp = Random.Range(0,4);

            if(tmp == 0)
            {
                audioSource.PlayOneShot(walk1);
            }
            else if(tmp == 1)
            {
                audioSource.PlayOneShot(walk2);
            }
            else if(tmp ==2)
            {
                audioSource.PlayOneShot(walk3);
            }
            else
            {
                audioSource.PlayOneShot(walk4);
            }
        }
    }
}