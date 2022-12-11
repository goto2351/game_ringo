using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer_main : MonoBehaviour
{
    // 鳴らすSE
    [SerializeField] private AudioClip SE_whistle; // 最初と最後に鳴らすホイッスル
    [SerializeField] private AudioClip SE_GetApple; // りんごを手に入れたとき
    [SerializeField] private AudioClip SE_HitEdge; // 枝に当たったとき
    [SerializeField] private AudioClip SE_GetPoint; // ダンボールに納品したとき
    // SEと名前の関連付け
    private Dictionary<string, AudioClip> SEdictionary = new Dictionary<string, AudioClip>();

    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        SEdictionary.Add("Whistle", SE_whistle);
        SEdictionary.Add("GetApple", SE_GetApple);
        SEdictionary.Add("HitEdge", SE_HitEdge);
        SEdictionary.Add("GetPoint", SE_GetPoint);

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    /// <summary>
    /// 指定されたSEを鳴らす
    /// </summary>
    /// <param name="SEname">SEの名前</param>
    public void playSE(string SEname)
    {
        // 鳴らすSEをセットして再生
        audioSource.clip = SEdictionary[SEname];
        if (audioSource.clip == null)
        {
            Debug.Log("Error: Failed to set AudioClip");
        }

        audioSource.Play();
    }

    public void SetSEVolume (float vol)
    {
        audioSource.volume = vol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
