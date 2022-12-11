using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // �t�B�[���h
    // ��񂲂̃v���n�u
    private GameObject apple_prefab;
    // �΂̃v���n�u
    private GameObject stone_prefab;
    // �A�C�e�������ʒu�̒[
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
            // �A�C�e���𐶐����钊�I
            // TODO: �����̒l�͒�������
            if (Random.Range(0, 100) == 1)
            {
                GameObject item; // ��������A�C�e��

                // �~�点��A�C�e���̒��I
                if (Random.Range(0, 100) <= 70)
                {
                    // ��񂲂̏ꍇ
                    item = Resources.Load<GameObject>("apple");
                }
                else
                {
                    // �΂̏ꍇ->�؂̎}�ɕύX
                    //item = Resources.Load<GameObject>("stone");
                    item = Resources.Load<GameObject>("edge");
                }

                // �~�点��ʒu�̌���
                Vector3 generate_pos = new Vector3(Random.Range(GENERATE_POS_MIN, GENERATE_POS_MAX), 4f, 0f);

                // �X�s�[�h�̌���
                float coeff = Random.Range(0.8f, 1.3f);

                // �A�C�e���𐶐�����
                GameObject generated_item = Instantiate(item, generate_pos, Quaternion.identity);
                // �X�s�[�h�̐ݒ�
                generated_item.AddComponent<ItemController>();
                generated_item.GetComponent<ItemController>().speed *= coeff;
            }
        }
    }
}

