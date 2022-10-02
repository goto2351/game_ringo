using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject UIText_Time;
    [SerializeField] GameObject UIText_Score;

    // キャラクター上のUI表示用
    [SerializeField] private Camera targetCamera;
    [SerializeField] private GameObject character; // UIを表示させる対象(キャラクター)
    [SerializeField] private GameObject UI_numApple; // 表示させるUI(りんごの数)
    [SerializeField] private GameObject UI_numApple_text; // りんごの数のテキスト
    private const float UI_NUMAPPLE_POS_Y = -38f; 


    private GameManager manager; 

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押すとゲーム開始
        if (Input.GetKeyDown(KeyCode.Space) && manager.isStarted == false)
        {
            manager.GameStart();
        }

        // 残り時間とスコアをUIに反映する
        UIText_Time.GetComponent<Text>().text = Mathf.CeilToInt(manager.resTime).ToString("D2");
        UIText_Score.GetComponent<Text>().text = manager.score.ToString("D6");

        // 持っているりんごの数を表示
        if (manager.isStarted)
        {
            UI_numApple.transform.localPosition = GetUIApplePosition();
            UI_numApple_text.GetComponent<Text>().text = "× " + character.GetComponent<PlayerController>().numApple;
        }
    }

    /// <summary>
    /// UI_numApple(りんごの数)の表示位置を求める
    /// </summary>
    /// <returns>Uiの表示位置</returns>
    private Vector3 GetUIApplePosition()
    {
        // 表示させる対象オブジェクトのワールド座標
        Vector3 targetWorldPos = character.transform.position;
        // スクリーン座標に変換
        Vector2 targetScreenPos = targetCamera.WorldToScreenPoint(targetWorldPos); // Vector3->Vector2にキャスト

        // 変換先UIローカル座標の親
        RectTransform parentUITransform = UI_numApple.transform.parent.GetComponent<RectTransform>();

        // UIローカル座標への変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentUITransform, targetScreenPos, null, out var uiLocalPos);

        uiLocalPos.y = UI_NUMAPPLE_POS_Y;

        return (Vector3)uiLocalPos;
    }
}
