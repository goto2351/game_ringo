using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // �e�i�K��Canvas
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject resultCanvas;

    // �Q�[�����̃e�L�X�g
    [SerializeField] GameObject UIText_Time;
    [SerializeField] GameObject UIText_Score;

    // �L�����N�^�[���UI�\���p
    [SerializeField] private Camera targetCamera;
    [SerializeField] private GameObject character; // UI��\��������Ώ�(�L�����N�^�[)
    [SerializeField] private GameObject UI_numApple; // �\��������UI(��񂲂̐�)
    [SerializeField] private GameObject UI_numApple_text; // ��񂲂̐��̃e�L�X�g
    private const float UI_NUMAPPLE_POS_Y = -38f;

    // ���ʉ�ʂ̃e�L�X�g
    [SerializeField] private GameObject resultText_Score;


    private GameManager manager; 

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ƃQ�[���J�n
        if (Input.GetKeyDown(KeyCode.Space) && manager.isStarted == false && manager.isAbleToStart == true)
        {
            manager.GameStart();
            startCanvas.SetActive(false);
            gameCanvas.SetActive(true);
        }

        // �c�莞�ԂƃX�R�A��UI�ɔ��f����
        UIText_Time.GetComponent<Text>().text = "Time: " + Mathf.CeilToInt(manager.resTime).ToString("D2");
        UIText_Score.GetComponent<Text>().text = "Score: " + manager.score.ToString("D6");

        // �����Ă����񂲂̐���\��
        if (manager.isStarted)
        {
            UI_numApple.transform.localPosition = GetUIApplePosition();
            UI_numApple_text.GetComponent<Text>().text = "�~ " + character.GetComponent<PlayerController>().numApple;
        }
    }

    /// <summary>
    /// �Q�[���I�����Ɍ��ʉ�ʂ�\������
    /// </summary>
    /// <param name="score">�X�R�A</param>
    public void ShowResult(int score)
    {
        // �\������UI��؂�ւ���
        gameCanvas.SetActive(false);
        resultCanvas.SetActive(true);
        resultText_Score.GetComponent<Text>().text = score.ToString();
    }

    /// <summary>
    /// �u������x�v���C�v�{�^���̃N���b�N�C�x���g
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// �u�^�C�g���֖߂�v�{�^���̃N���b�N�C�x���g
    /// </summary>
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary>
    /// UI_numApple(��񂲂̐�)�̕\���ʒu�����߂�
    /// </summary>
    /// <returns>Ui�̕\���ʒu</returns>
    private Vector3 GetUIApplePosition()
    {
        // �\��������ΏۃI�u�W�F�N�g�̃��[���h���W
        Vector3 targetWorldPos = character.transform.position;
        // �X�N���[�����W�ɕϊ�
        Vector2 targetScreenPos = targetCamera.WorldToScreenPoint(targetWorldPos); // Vector3->Vector2�ɃL���X�g

        // �ϊ���UI���[�J�����W�̐e
        RectTransform parentUITransform = UI_numApple.transform.parent.GetComponent<RectTransform>();

        // UI���[�J�����W�ւ̕ϊ�
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentUITransform, targetScreenPos, null, out var uiLocalPos);

        uiLocalPos.y = UI_NUMAPPLE_POS_Y;

        return (Vector3)uiLocalPos;
    }
}
