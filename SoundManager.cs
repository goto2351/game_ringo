using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    // �t�B�[���h
    // ����
    private float volume { get; set; } = 1f;

    private AudioSource sePlayer;

    // Start is called before the first frame update
    void Start()
    {
        sePlayer = gameObject.GetComponent<AudioSource>();
        sePlayer.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Resources�̒��ɂ���SE��ǂݍ���
    /// </summary>
    /// <param name="path">�ǂݍ���SE�̃p�X</param>
    /// <returns></returns>
    public AudioClip LoadSE(string path)
    {
        return Resources.Load<AudioClip>(path);
    }

    /// <summary>
    /// SE��炷
    /// </summary>
    /// <param name="se">�炷SE(AudioClip)</param>
    public void PlaySE(AudioClip se)
    {
        sePlayer.clip = se;
        sePlayer.Play();
    }
}
