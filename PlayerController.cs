using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    // �t�B�[���h
#pragma warning disable 0414
    private GameManager manager;
    // �ړ����x
    private float speed { get; set; } = 5f;
    // �����̒��̂�񂲂̐�
    public int numApple = 0;
    // �����u����ɂ��邩�ǂ���
    private bool isOnBox = false;
    // ��񂲂ɓ�����������SE
    private AudioClip se_Apple;
    // �΂ɓ�����������SE
    private AudioClip se_stone;
    // �����̃p���̐U�ꕝ
    private const float SE_MAX_PAN = 0.3f;
    private const float STAGE_WIDTH = 8.8f;

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource; // �����p

    // �w�i�̃R���g���[���p
    private GameObject backGround;
    private const float DEFAULT_BG_X = -2f;
    private const float BG_MOVE_WIDTH = 0.5f;
    private const float DEFAULT_PLAYER_X = -4.5f;

    //TODO: SoundController, GameManager�̃C���X�^���X��������
#pragma warning restore 0414

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g��ݒ肷��
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
        // �u����ɂ���Ƃ��A�X�y�[�X�L�[�ł�񂲂�u��
        if (Input.GetKeyDown(KeyCode.Space) && isOnBox)
        {
            int point = manager.calcPutScore(numApple);
            if (point > 0)
            {
                manager.AddScore(point);
                // SE��炷
                manager.playSE("GetPoint");
                numApple = 0;
            }
            
        }

        // �����̃p���𒲐�����
        float pan = (gameObject.transform.position.x / STAGE_WIDTH) * SE_MAX_PAN;
        audioSource.panStereo = pan;

        // �w�i�𓮂���
        float term1 = (gameObject.transform.position.x - DEFAULT_PLAYER_X) / STAGE_WIDTH;
        float bg_newPos = DEFAULT_BG_X - term1 * BG_MOVE_WIDTH;
        backGround.transform.position = new Vector3(bg_newPos, 0.8f, 0.4f);
    }

    private void FixedUpdate()
    {
        // ���E�̃L�[��������Ă���Ƃ��ړ�����
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRunning", true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // ������炷
            }
        } else
        {
            anim.SetBool("isRunning", false);
            if(audioSource.isPlaying)
            {
                audioSource.Stop(); // �������~�߂�
            }
        }

        // �L�����N�^�[�̌�����i�s�����ɍ��킹��
        Vector3 scale = gameObject.transform.localScale;

        if (horizontalInput < 0 && scale.x > 0 || horizontalInput > 0 && scale.x < 0)
        {
            scale.x *= -1;
        }

        gameObject.transform.localScale = scale;
    }

    // �����蔻��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��񂲂ɓ���������
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
            // ��񂲂̔��ɐG�ꂽ�Ƃ�(��񂲂�u�����ԂɂȂ����Ƃ�)
            isOnBox = true;
        }
    }

    /// <summary>
    /// �Q�[���I�����ɃL�����N�^�[���~�߂�
    /// </summary>
    private void OnDisable()
    {
        rb.velocity = new Vector2(0f, 0f);
        anim.SetBool("isRunning", false);
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // �������~�߂�
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ��񂲂̔��𗣂ꂽ�Ƃ�(��񂲂�u�����ԂłȂ��Ȃ����Ƃ�)
        if (collision.gameObject.tag == "box")
        {
            isOnBox = false;
        }
    }
}
