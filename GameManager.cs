using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�@�t�B�[���h
    // �c�莞��
    public float resTime { get; private set; } = 60f;
    // �Q�[���̊J�n���
    public bool isStarted { get; private set; } = false;
    //�X�R�A
    public int score { get;  private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �f�o�b�O�p
        //GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            // �c�莞�Ԃ���������
            resTime -= Time.deltaTime;

            // ���Ԑ؂�̂Ƃ�
            if (resTime <= 0)
            {
                GameEnd();
            }
        }
    }

    /// <summary>
    /// �Q�[���̊J�n�������s��
    /// ItemGenerator, PlayerController������
    /// </summary>
    public void GameStart()
    {
        Debug.Log("started");
        // �J�n�t���O�𗧂Ă�
        isStarted = true;

        // TODO: �R���|�[�l���g��t����
        GameObject.FindGameObjectsWithTag("Player")[0].AddComponent<PlayerController>();
        gameObject.AddComponent<ItemGenerator>();
    }

    /// <summary>
    /// �Q�[���̏I���������s��
    /// �R���|�[�l���g�����
    /// </summary>
    public void GameEnd()
    {
        // �J�n�t���O��܂�
        isStarted = false;

        // TODO: �R���|�[�l���g�����, ���b�Z�[�W���o��
    }

    /// <summary>
    /// �X�R�A�����Z����
    /// </summary>
    /// <param name="plusScore">���Z����X�R�A</param>
    public void AddScore(int plusScore)
    {
        score += plusScore;
    }

    /// <summary>
    /// ��񂲂�u�����Ƃ��ɉ��Z����X�R�A�����߂�
    /// </summary>
    /// <param name="numApple">�����Ă����񂲂̐�</param>
    /// <returns>���Z����X�R�A</returns>
    public int calcPutScore(int numApple)
    {
        float gainScore = 200 * Mathf.Pow(1.1f, numApple) * numApple;
        return Mathf.CeilToInt(gainScore);
    }

}
