using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;     // ���� ����
    [SerializeField] private TextMeshProUGUI timeText;    // �����ð� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI scoreText;   // ���� ǥ�� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI bestText;    // �ְ� ��� ǥ�� �ؽ�Ʈ
    [SerializeField] private Button restartBtn;           // ����� ��ư


    private float surviveTime;  // ������ �ð�
    int score = 0; // ���� ����
    public bool isGameOver = false; // ���� ���� ����


    void Start()
    {
        Time.timeScale = 1;
        gameOverText.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score : " + score;

        // ���� �������
        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
            restartBtn.gameObject.SetActive(true);

            // �����
            Restart();
        }


        // ���� �ð� ����
        surviveTime += Time.deltaTime;
        timeText.text = "Time : " + (int)surviveTime; // ���� �ð� ǥ��

        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void AddScore()
    {
        score++;
    }

    public void Reload() // ����� ��ư�� ������ ������ϱ�
    {
        SceneManager.LoadScene(0); 
    }

    public void EndGame()
    {
        isGameOver = true;
        // StartCoroutine(GameOverTextCo());

        // �ְ� ��� ��������
        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f); // �⺻�� 0���� ����

        // ���� ������ ������ �ְ� ��Ϻ��� ũ��
        if (score > bestScore)
        {
            // �����ض� (�ְ� ������)
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save(); // �����ϱ�
        }

        // �ְ� ���� �ؽ�Ʈ ǥ��
        scoreText.text = "Best Score : " + (int)bestScore;
    }


}
