using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] List<SESoundData> seSoundDatas;
    [SerializeField] List<SourceData> SourceDatas;

    public float masterVolume = 1;
    public float seMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySE(SESoundData.SE se,SourceData.Source source)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        SourceData sdata = SourceDatas.Find(sdata => sdata.source == source);
        AudioSource seAudioSource = sdata.audioSource;

        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Attack,
        Damage,
        Hoge, // これがラベルになる
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SourceData
{
    public enum Source
    {
        Attack,
        Damage,
        Hoge, // これがラベルになる
    }

    public Source source;
    public AudioSource audioSource;
}