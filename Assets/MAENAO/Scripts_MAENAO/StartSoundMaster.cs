using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoundMaster : MonoBehaviour
{
    public AudioClip SE1;


    // Start is called before the first frame update
    void Start()
    {
        SoundMaster.instance.PlaySE(SE1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
