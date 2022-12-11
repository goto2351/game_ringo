using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] GameObject howToPlayCanvas;
    [SerializeField] GameObject titleMainCanvas;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource audioSource;

    /// <summary>
    /// �V�ѕ���\������
    /// </summary>
    public void ShowHowToPlay()
    {
        titleMainCanvas.SetActive(false);
        howToPlayCanvas.SetActive(true);
    }

    /// <summary>
    /// ���C���V�[����ǂݍ��݃Q�[�����J�n����
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// �u�V�ѕ��v��ʂ����
    /// </summary>
    public void ShowTitle()
    {
        howToPlayCanvas.SetActive(false);
        titleMainCanvas.SetActive(true);
    }

    /// <summary>
    /// �X�N���[���o�[�ɂ�鉹�ʒ���
    /// </summary>
    public void ChangeVolume()
    {
        Config.volume = volumeSlider.value;
        audioSource.volume = Config.volume;
        if (Mathf.CeilToInt(volumeSlider.value * 100f) % 10 == 0)
        {
            audioSource.Play();
        }
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
