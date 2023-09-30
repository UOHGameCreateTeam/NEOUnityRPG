using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSE : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] tkp_get_key_input tkp;
    public AudioClip walk1;
    public AudioClip walk2;
    public AudioClip walk3;
    public AudioClip walk4;
    public AudioClip jump;
    int walkTimer_;
    int walkStride =25;
    int flag = 0;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateFootSound(tkp.Is_ground());
    }
    public void UpdateFootSound(bool triger)
    {
        //移動時、タイマーインクリメント　要、移動キー再設定
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jump);
            Debug.Log("おしたよー");
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
        
        if((walkTimer_ == 2 || walkTimer_%walkStride ==0) && triger == true)
        {
            //一定間隔で足音を鳴らす。
            RandomizeSfx(walk1, walk2, walk3, walk4);
        }
    }
    public void RandomizeSfx ( params AudioClip[] clips )
    {
        var randomIndex = Random.Range(0, clips.Length);
        audioSource.PlayOneShot ( clips[randomIndex] );
    }
}
