using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaTest1 : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
        }
        //下入力時SE2を流す
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Hoge);
        }
    }
    void FixedUpdate()
    {
        SoundMaster.instance.UpdateFootSound();
    }
}