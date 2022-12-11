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
    /// 遊び方を表示する
    /// </summary>
    public void ShowHowToPlay()
    {
        titleMainCanvas.SetActive(false);
        howToPlayCanvas.SetActive(true);
    }

    /// <summary>
    /// メインシーンを読み込みゲームを開始する
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// 「遊び方」画面を閉じる
    /// </summary>
    public void ShowTitle()
    {
        howToPlayCanvas.SetActive(false);
        titleMainCanvas.SetActive(true);
    }

    /// <summary>
    /// スクロールバーによる音量調節
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
