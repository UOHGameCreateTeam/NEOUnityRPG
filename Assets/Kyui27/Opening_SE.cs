using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_SE : MonoBehaviour
{
    public AudioClip BGMData;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = BGMData;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
