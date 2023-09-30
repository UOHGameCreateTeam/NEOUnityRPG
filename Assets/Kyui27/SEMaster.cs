using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEMaster : MonoBehaviour
{
    AudioSource audioSource = null;
    //以下、鳴らしたい音の分だけ追加。
    public AudioClip ex;

    // Start is called before the first frame update
    void Start()
    {
        //各種GetComponent
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //SEを流したい箇所に以下のif文を追加する

        //例)上入力時exを流す
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //SoundMasterのPlaySE()に音源データを渡す.
            PlaySE(ex);
            //SoundMasterのPlaySE()に音源データを渡す.
            //PlaySE()は渡された音源を流すメソッド
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            //SoundMasterのPlaySE()に音源データを渡す.
            PlaySE(ex);
            //SoundMasterのPlaySE()に音源データを渡す.
            //PlaySE()は渡された音源を流すメソッド
        }
    }

    public void PlaySE(AudioClip clip)
    {
        if(clip != null){
            //引数が正しく与えられればPlayOneShot。重ね掛け可能
            audioSource.PlayOneShot(clip) ;
        }
    }
}