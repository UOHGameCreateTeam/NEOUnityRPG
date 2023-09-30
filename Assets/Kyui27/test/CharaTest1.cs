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
        //下入力時SE2を流す
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.test1,SourceData.Source.test1);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.test2,SourceData.Source.test2);
        }
    }
    void FixedUpdate()
    {
        SoundMaster.instance.UpdateFootSound();
    }
}