using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    // フィールド
    // 音量
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
    /// Resourcesの中にあるSEを読み込む
    /// </summary>
    /// <param name="path">読み込むSEのパス</param>
    /// <returns></returns>
    public AudioClip LoadSE(string path)
    {
        return Resources.Load<AudioClip>(path);
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    /// <param name="se">鳴らすSE(AudioClip)</param>
    public void PlaySE(AudioClip se)
    {
        sePlayer.clip = se;
        sePlayer.Play();
    }
}
