using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    // フィールド
#pragma warning disable 0414
    // 移動速度
    private float speed { get; set; } = 5f;
    // かごの中のりんごの数
    private int numApple = 0;
    // かご置き場にいるかどうか
    private bool isOnBox = false;
    // りんごに当たった時のSE
    private AudioClip se_Apple;
    // 石に当たった時のSE
    private AudioClip se_stone;

    private Rigidbody2D rb;
    //TODO: SoundController, GameManagerのインスタンスを加える
#pragma warning restore 0414

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを設定する
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 左右のキーが押されているとき移動する
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
}
