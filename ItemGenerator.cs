using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // フィールド
    // りんごのプレハブ
    private GameObject apple_prefab;
    // 石のプレハブ
    private GameObject stone_prefab;
    // アイテム生成位置の端
    const float GENERATE_POS_MAX = 5.5f;
    const float GENERATE_POS_MIN = -8f;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        if (manager.isStarted)
        {
            // アイテムを生成する抽選
            // TODO: ここの値は調整する
            if (Random.Range(0, 100) == 1)
            {
                GameObject item; // 生成するアイテム

                // 降らせるアイテムの抽選
                if (Random.Range(0, 100) <= 70)
                {
                    // りんごの場合
                    item = Resources.Load<GameObject>("apple");
                }
                else
                {
                    // 石の場合->木の枝に変更
                    //item = Resources.Load<GameObject>("stone");
                    item = Resources.Load<GameObject>("edge");
                }

                // 降らせる位置の決定
                Vector3 generate_pos = new Vector3(Random.Range(GENERATE_POS_MIN, GENERATE_POS_MAX), 4f, 0f);

                // スピードの決定
                float coeff = Random.Range(0.8f, 1.3f);

                // アイテムを生成する
                GameObject generated_item = Instantiate(item, generate_pos, Quaternion.identity);
                // スピードの設定
                generated_item.AddComponent<ItemController>();
                generated_item.GetComponent<ItemController>().speed *= coeff;
            }
        }
    }
}

