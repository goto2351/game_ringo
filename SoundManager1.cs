using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager1 : MonoBehaviour 
{ 
    [SerializeField] private GameObject bgmManager;
    [SerializeField] private SEPlayer_main sePlayer;
    private float INITIAL_VOLUME_BGM = 0.5f;
    private float INITIAL_VOLUME_SE = 1f;

    /// <summary>
    /// ボリュームを設定する
    /// </summary>
    /// <param name="coeff">Configクラスから取る係数</param>
    public void SetVolume(float coeff)
    {
        bgmManager.GetComponent<AudioSource>().volume = INITIAL_VOLUME_BGM * coeff;
        sePlayer.SetSEVolume(INITIAL_VOLUME_SE * coeff);
    }
    /// <summary>
    /// BGMの再生を開始する
    /// </summary>
    public void StartBGM()
    {
        bgmManager.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// BGMの再生を停止する
    /// </summary>
    public void StopBGM()
    {
        bgmManager.GetComponent<AudioSource>().Stop();
    }

    /// <summary>
    /// 指定されたSEを再生する
    /// </summary>
    /// <param name="SEname">鳴らすSEの名前</param>
    public void PlaySE(string SEname)
    {
        sePlayer.playSE(SEname);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
