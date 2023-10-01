using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSE : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] tkp_get_key_input tkp;
    //[SerializeField] TAMIYANOMAR_inside_siro inside_siro;
    public AudioClip walk1;
    public AudioClip walk2;
    public AudioClip walk3;
    public AudioClip walk4;
    public AudioClip walk5;
    public AudioClip walk6;
    public AudioClip walk7;
    public AudioClip walk8;
    public AudioClip jump;
    public AudioClip landing;
    int walkTimer_;
    int walkStride =25;
    bool jumped = false;
    bool indoor = false;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump(tkp.Is_ground());
        //indoor = inside_siro.get_inside_or_not();
    }
    void FixedUpdate()
    {
        UpdateFootSound(tkp.Is_ground());
    }
    public void UpdateFootSound(bool Is_ground)
    {
        //移動時、タイマーインクリメント　要、移動キー再設定
        if((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.S)) && Is_ground == true)
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
        
        if((walkTimer_ == 2 || walkTimer_%walkStride ==0) && Is_ground == true && indoor == false)
        {
            //outside
            RandomizeSfx(walk1, walk2, walk3, walk4);
        }
        if((walkTimer_ == 2 || walkTimer_%walkStride ==0) && Is_ground == true && indoor == true)
        {
            //inside
            RandomizeSfx(walk5, walk6, walk7, walk8);
        }
    }
    public void Jump(bool Is_ground)
    {
        if(Input.GetKeyDown(KeyCode.Space) && Is_ground == true)
        {
            audioSource.PlayOneShot(jump);
        }
        if(Is_ground == false && jumped == false){
            jumped = true;
            Debug.Log("ジャンプ");
        }
        if(Is_ground == true && jumped == true){
            audioSource.PlayOneShot(landing);
            Debug.Log("着地");
            jumped = false;
        }        
    }
    
    public void RandomizeSfx ( params AudioClip[] clips )
    {
        var randomIndex = Random.Range(0, clips.Length);
        audioSource.PlayOneShot ( clips[randomIndex] );
    }
}
