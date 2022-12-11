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
    // 足音のパンの振れ幅
    private const float SE_MAX_PAN = 0.3f;
    private const float STAGE_WIDTH = 8.8f;

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource; // 足音用

    // 背景のコントロール用
    private GameObject backGround;
    private const float DEFAULT_BG_X = -2f;
    private const float BG_MOVE_WIDTH = 0.5f;
    private const float DEFAULT_PLAYER_X = -4.5f;

    //TODO: SoundController, GameManagerのインスタンスを加える
#pragma warning restore 0414

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを設定する
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = Config.volume;
        backGround = GameObject.Find("backgrounds");
    }

    // Update is called once per frame
    void Update()
    {
        // 置き場にいるとき、スペースキーでりんごを置く
        if (Input.GetKeyDown(KeyCode.Space) && isOnBox)
        {
            int point = manager.calcPutScore(numApple);
            if (point > 0)
            {
                manager.AddScore(point);
                // SEを鳴らす
                manager.playSE("GetPoint");
                numApple = 0;
            }
            
        }

        // 足音のパンを調整する
        float pan = (gameObject.transform.position.x / STAGE_WIDTH) * SE_MAX_PAN;
        audioSource.panStereo = pan;

        // 背景を動かす
        float term1 = (gameObject.transform.position.x - DEFAULT_PLAYER_X) / STAGE_WIDTH;
        float bg_newPos = DEFAULT_BG_X - term1 * BG_MOVE_WIDTH;
        backGround.transform.position = new Vector3(bg_newPos, 0.8f, 0.4f);
    }

    private void FixedUpdate()
    {
        // 左右のキーが押されているとき移動する
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRunning", true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // 足音を鳴らす
            }
        } else
        {
            anim.SetBool("isRunning", false);
            if(audioSource.isPlaying)
            {
                audioSource.Stop(); // 足音を止める
            }
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
            manager.playSE("GetApple");
            Destroy(collision.gameObject);
            //GameObject.Find("Manager").GetComponent<GameManager>().AddScore(100);
            manager.AddScore(100);
            numApple++;
        }
        else if (collision.gameObject.tag == "stone")
        {
            manager.playSE("HitEdge");
            Destroy(collision.gameObject);
            numApple = 0;
        }
        else if (collision.gameObject.tag == "box")
        {
            // りんごの箱に触れたとき(りんごを置ける状態になったとき)
            isOnBox = true;
        }
    }

    /// <summary>
    /// ゲーム終了時にキャラクターを止める
    /// </summary>
    private void OnDisable()
    {
        rb.velocity = new Vector2(0f, 0f);
        anim.SetBool("isRunning", false);
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // 足音を止める
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
