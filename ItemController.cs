using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class ItemController : MonoBehaviour
{
    // �t�B�[���h
    // �������x
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // TODO: ���ɂ�������destroy����
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y -= speed * Time.deltaTime;
        gameObject.transform.position = pos;
    }

    // ���ɗ������Ƃ��I�u�W�F�N�g������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
