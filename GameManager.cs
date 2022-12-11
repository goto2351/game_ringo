using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //　フィールド
    // 残り時間
    public float resTime { get; private set; } = 65f;
    // ゲームの開始状態
    public bool isStarted { get; private set; } = false;
    public bool isAbleToStart { get; private set; } = true;
    //スコア
    public int score { get;  private set; } = 0;

    private SoundManager1 soundManager;

    // Start is called before the first frame update
    void Start()
    {
        // デバッグ用
        //GameStart();
        soundManager = gameObject.GetComponent<SoundManager1>();
        soundManager.SetVolume(Config.volume);
    }

    /// <summary>
    /// 指定されたSEを鳴らす
    /// </summary>
    /// <param name="SEname">SEの名前</param>
    public void playSE(string SEname)
    {
        soundManager.PlaySE(SEname);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            // 残り時間を差し引く
            resTime -= Time.deltaTime;

            // 時間切れのとき
            if (resTime <= 0)
            {
                GameEnd();
            }
        }
    }

    /// <summary>
    /// ゲームの開始処理を行う
    /// ItemGenerator, PlayerControllerをつける
    /// </summary>
    public void GameStart()
    {
        Debug.Log("started");
        // 開始フラグを立てる
        isStarted = true;
        // SEを鳴らす
        playSE("Whistle");
        soundManager.StartBGM();
        // TODO: コンポーネントを付ける
        GameObject.FindGameObjectsWithTag("Player")[0].AddComponent<PlayerController>();
        gameObject.AddComponent<ItemGenerator>();

        isAbleToStart = false;
    }

    /// <summary>
    /// ゲームの終了処理を行う
    /// コンポーネントを取る
    /// </summary>
    public void GameEnd()
    {
        // 開始フラグを折る
        isStarted = false;
        // todo: 笛の音か何か鳴らす
        playSE("Whistle");
        //gameObject.GetComponent<UIController>().ShowResult(score);
        Invoke(nameof(CallShowResult), 1f);
        Invoke(nameof(CallStopBGM), 1.5f);
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>().enabled = false;
    }

    private void CallStopBGM()
    {
        soundManager.StopBGM();
    }

    /// <summary>
    /// 結果画面を表示する(GameEnd()からの呼び出し用
    /// </summary>
    private void CallShowResult()
    {
        gameObject.GetComponent<UIController>().ShowResult(score);
    }
    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="plusScore">加算するスコア</param>
    public void AddScore(int plusScore)
    {
        score += plusScore;
    }

    /// <summary>
    /// りんごを置いたときに加算するスコアを求める
    /// </summary>
    /// <param name="numApple">持っているりんごの数</param>
    /// <returns>加算するスコア</returns>
    public int calcPutScore(int numApple)
    {
        float gainScore = 200 * Mathf.Pow(1.1f, numApple) * numApple;
        return Mathf.CeilToInt(gainScore);
    }

}
