using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// BGM����
    /// </summary>
    [SerializeField] AudioClip[] ACSource;

    AudioSource bgm;

    /// <summary>
    /// ���񭵼�
    /// </summary>
    /// <param name="bgmID">�n���񪺭��֡A�Y�����ȹw�]���s����W�����񪺭���</param>
    /// <param name="loop">�O�_�`��</param>
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
    /// �Ȱ����񭵼�
    /// </summary>
    public void Pause()
    {
        bgm.Pause();
    }

    /// <summary>
    /// �~�򼷩񭵼�
    /// </summary>
    public void Replay()
    {
        bgm.UnPause();
    }

    /// <summary>
    /// �����Τ�������
    /// </summary>
    public void Stop()
    {
        bgm.Stop();
    }

    /// <summary>
    /// �󴫭���
    /// </summary>
    /// <param name="bgmID2Change">�n�󴫪�����</param>
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

        DontDestroyOnLoad(this.gameObject); //�b���������ɤ��R���o�Ӫ���
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
