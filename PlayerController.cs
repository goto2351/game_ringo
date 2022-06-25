using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    // �t�B�[���h
#pragma warning disable 0414
    // �ړ����x
    private float speed { get; set; } = 5f;
    // �����̒��̂�񂲂̐�
    private int numApple = 0;
    // �����u����ɂ��邩�ǂ���
    private bool isOnBox = false;
    // ��񂲂ɓ�����������SE
    private AudioClip se_Apple;
    // �΂ɓ�����������SE
    private AudioClip se_stone;

    private Rigidbody2D rb;
    //TODO: SoundController, GameManager�̃C���X�^���X��������
#pragma warning restore 0414

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g��ݒ肷��
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // ���E�̃L�[��������Ă���Ƃ��ړ�����
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
}
