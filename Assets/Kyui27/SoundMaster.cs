using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    public static SoundMaster instance = null;
    AudioSource audioSource = null;
    AudioSource BGM = null;

    private void Awake(){
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
        audioSource = GetComponent<AudioSource>();
        BGM = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySE(AudioClip clip)
    {
        if(clip != null){
            audioSource.PlayOneShot(clip) ;
        }
    }
    public void PlayBGM(AudioClip clip)
    {
        BGM.clip = clip;
        if(BGM != null){
            BGM.Play() ;
        }
    }
}
