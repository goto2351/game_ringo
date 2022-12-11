using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer_main : MonoBehaviour
{
    // �炷SE
    [SerializeField] private AudioClip SE_whistle; // �ŏ��ƍŌ�ɖ炷�z�C�b�X��
    [SerializeField] private AudioClip SE_GetApple; // ��񂲂���ɓ��ꂽ�Ƃ�
    [SerializeField] private AudioClip SE_HitEdge; // �}�ɓ��������Ƃ�
    [SerializeField] private AudioClip SE_GetPoint; // �_���{�[���ɔ[�i�����Ƃ�
    // SE�Ɩ��O�̊֘A�t��
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
    /// �w�肳�ꂽSE��炷
    /// </summary>
    /// <param name="SEname">SE�̖��O</param>
    public void playSE(string SEname)
    {
        // �炷SE���Z�b�g���čĐ�
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
