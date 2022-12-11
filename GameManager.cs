using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�@�t�B�[���h
    // �c�莞��
    public float resTime { get; private set; } = 65f;
    // �Q�[���̊J�n���
    public bool isStarted { get; private set; } = false;
    public bool isAbleToStart { get; private set; } = true;
    //�X�R�A
    public int score { get;  private set; } = 0;

    private SoundManager1 soundManager;

    // Start is called before the first frame update
    void Start()
    {
        // �f�o�b�O�p
        //GameStart();
        soundManager = gameObject.GetComponent<SoundManager1>();
        soundManager.SetVolume(Config.volume);
    }

    /// <summary>
    /// �w�肳�ꂽSE��炷
    /// </summary>
    /// <param name="SEname">SE�̖��O</param>
    public void playSE(string SEname)
    {
        soundManager.PlaySE(SEname);
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
        // SE��炷
        playSE("Whistle");
        soundManager.StartBGM();
        // TODO: �R���|�[�l���g��t����
        GameObject.FindGameObjectsWithTag("Player")[0].AddComponent<PlayerController>();
        gameObject.AddComponent<ItemGenerator>();

        isAbleToStart = false;
    }

    /// <summary>
    /// �Q�[���̏I���������s��
    /// �R���|�[�l���g�����
    /// </summary>
    public void GameEnd()
    {
        // �J�n�t���O��܂�
        isStarted = false;
        // todo: �J�̉��������炷
        playSE("Whistle");
        //gameObject.GetComponent<UIController>().ShowResult(score);
        Invoke(nameof(CallShowResult), 1f);
        Invoke(nameof(CallStopBGM), 1.5f);
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>().enabled = false;
    }

    private void CallStopBGM()
    {
        soundManager.StopBGM();
    }

    /// <summary>
    /// ���ʉ�ʂ�\������(GameEnd()����̌Ăяo���p
    /// </summary>
    private void CallShowResult()
    {
        gameObject.GetComponent<UIController>().ShowResult(score);
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
