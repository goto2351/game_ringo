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
    /// �{�����[����ݒ肷��
    /// </summary>
    /// <param name="coeff">Config�N���X������W��</param>
    public void SetVolume(float coeff)
    {
        bgmManager.GetComponent<AudioSource>().volume = INITIAL_VOLUME_BGM * coeff;
        sePlayer.SetSEVolume(INITIAL_VOLUME_SE * coeff);
    }
    /// <summary>
    /// BGM�̍Đ����J�n����
    /// </summary>
    public void StartBGM()
    {
        bgmManager.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// BGM�̍Đ����~����
    /// </summary>
    public void StopBGM()
    {
        bgmManager.GetComponent<AudioSource>().Stop();
    }

    /// <summary>
    /// �w�肳�ꂽSE���Đ�����
    /// </summary>
    /// <param name="SEname">�炷SE�̖��O</param>
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
