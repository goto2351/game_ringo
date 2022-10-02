using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //　フィールド
    // 残り時間
    public float resTime { get; private set; } = 60f;
    // ゲームの開始状態
    public bool isStarted { get; private set; } = false;
    //スコア
    public int score { get;  private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        // デバッグ用
        //GameStart();
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

        // TODO: コンポーネントを付ける
        GameObject.FindGameObjectsWithTag("Player")[0].AddComponent<PlayerController>();
        gameObject.AddComponent<ItemGenerator>();
    }

    /// <summary>
    /// ゲームの終了処理を行う
    /// コンポーネントを取る
    /// </summary>
    public void GameEnd()
    {
        // 開始フラグを折る
        isStarted = false;

        // TODO: コンポーネントを取る, メッセージを出す
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
