using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    // フィールド
#pragma warning disable 0414
    private GameManager manager;
    // 移動速度
    private float speed { get; set; } = 5f;
    // かごの中のりんごの数
    public int numApple = 0;
    // かご置き場にいるかどうか
    private bool isOnBox = false;
    // りんごに当たった時のSE
    private AudioClip se_Apple;
    // 石に当たった時のSE
    private AudioClip se_stone;

    private Rigidbody2D rb;
    private Animator anim;
    //TODO: SoundController, GameManagerのインスタンスを加える
#pragma warning restore 0414

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを設定する
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 置き場にいるとき、スペースキーでりんごを置く
        if (Input.GetKeyDown(KeyCode.Space) && isOnBox)
        {
            manager.AddScore(manager.calcPutScore(numApple));
            Debug.Log(manager.calcPutScore(numApple));
            numApple = 0;
        }
    }

    private void FixedUpdate()
    {
        // 左右のキーが押されているとき移動する
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        // キャラクターの向きを進行方向に合わせる
        Vector3 scale = gameObject.transform.localScale;

        if (horizontalInput < 0 && scale.x > 0 || horizontalInput > 0 && scale.x < 0)
        {
            scale.x *= -1;
        }

        gameObject.transform.localScale = scale;
    }

    // 当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // りんごに当たった時
        if (collision.gameObject.tag == "apple")
        {
            // todo: SEなど
            Destroy(collision.gameObject);
            //GameObject.Find("Manager").GetComponent<GameManager>().AddScore(100);
            manager.AddScore(100);
            numApple++;
        }
        else if (collision.gameObject.tag == "stone")
        {
            Destroy(collision.gameObject);
            numApple = 0;
        }
        else if (collision.gameObject.tag == "box")
        {
            // りんごの箱に触れたとき(りんごを置ける状態になったとき)
            isOnBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // りんごの箱を離れたとき(りんごを置ける状態でなくなったとき)
        if (collision.gameObject.tag == "box")
        {
            isOnBox = false;
        }
    }
}
