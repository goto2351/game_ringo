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

    private Rigidbody2D rb;
    private Animator anim;
    //TODO: SoundController, GameManager�̃C���X�^���X��������
#pragma warning restore 0414

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g��ݒ肷��
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // �u����ɂ���Ƃ��A�X�y�[�X�L�[�ł�񂲂�u��
        if (Input.GetKeyDown(KeyCode.Space) && isOnBox)
        {
            manager.AddScore(manager.calcPutScore(numApple));
            Debug.Log(manager.calcPutScore(numApple));
            numApple = 0;
        }
    }

    private void FixedUpdate()
    {
        // ���E�̃L�[��������Ă���Ƃ��ړ�����
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
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
            // todo: SE�Ȃ�
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
            // ��񂲂̔��ɐG�ꂽ�Ƃ�(��񂲂�u�����ԂɂȂ����Ƃ�)
            isOnBox = true;
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
