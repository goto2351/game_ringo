using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class ItemController : MonoBehaviour
{
    // フィールド
    // 落下速度
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // TODO: 下におちた後destroyする
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y -= speed * Time.deltaTime;
        gameObject.transform.position = pos;
    }

    // 下に落ちたときオブジェクトを消す
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
