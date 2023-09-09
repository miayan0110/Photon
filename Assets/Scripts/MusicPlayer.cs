using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// BGM音檔
    /// </summary>
    [SerializeField] AudioClip[] ACSource;

    AudioSource bgm;

    /// <summary>
    /// 撥放音樂
    /// </summary>
    /// <param name="bgmID">要播放的音樂，若不給值預設重新撥放上次撥放的音樂</param>
    /// <param name="loop">是否循環</param>
    public void Play(string bgmID = "", bool loop = false)
    {
        if (bgm.clip == null)
        {
            bgm.clip = ACSource[0];
        }

        if (bgmID != "")
        {
            bgm.clip = Array.Find(ACSource, source => source.name == bgmID);
        }
        bgm.loop = loop;
        bgm.Play();
    }

    /// <summary>
    /// 暫停撥放音樂
    /// </summary>
    public void Pause()
    {
        bgm.Pause();
    }

    /// <summary>
    /// 繼續撥放音樂
    /// </summary>
    public void Replay()
    {
        bgm.UnPause();
    }

    /// <summary>
    /// 停止播放或切換音樂
    /// </summary>
    public void Stop()
    {
        bgm.Stop();
    }

    /// <summary>
    /// 更換音源
    /// </summary>
    /// <param name="bgmID2Change">要更換的音源</param>
    public void ChangeMusicSource(string bgmID2Change)
    {
        bgm.clip = Array.Find(ACSource, source => source.name == bgmID2Change);
    }

    public bool IsMusicPlaying()
    {
        return bgm.isPlaying;
    }

    void Awake()
    {
        bgm = this.gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject); //在切換場景時不刪除這個物件
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
