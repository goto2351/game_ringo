using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // フィールド
    // 落下速度
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y -= speed * Time.deltaTime;
        gameObject.transform.position = pos;
    }
}
