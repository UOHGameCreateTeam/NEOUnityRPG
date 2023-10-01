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

    public void UpdateFootSound(){
    }
}