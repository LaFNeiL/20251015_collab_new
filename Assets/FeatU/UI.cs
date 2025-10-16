using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("���� �г�")]
    [SerializeField] private GameObject gameOverPanel;    // ��ο� ��� �г�
    [Header("���� �ؽ�Ʈ")]
    [SerializeField] private GameObject gameOverText;     // ���� ���� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI timeText;    // ���� �ð� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI scoreText;   // ���� ���� ǥ�� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI bestText;    // �ְ� ���� ǥ�� �ؽ�Ʈ
    [Header("���� ��ư")]
    [SerializeField] private Button restartBtn;           // ����� ��ư
    [SerializeField] private Button exitBtn;              // ���� ��ư


    private float surviveTime;  // ������ �ð�
    private int score = 0; // ���� ����
    [Header("���� ���� ����")]
    public bool isGameOver = false; // ���� ���� ����


    void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);         // ���� ���� �г� ����
        gameOverText.SetActive(false);          // ���� ���� �ؽ�Ʈ ����
        restartBtn.gameObject.SetActive(false); // ����� ��ư ����
        exitBtn.gameObject.SetActive(false);    // ���� ��ư ����
        bestText.gameObject.SetActive(false);   // �ְ� ���� �ؽ�Ʈ ����
    }

    void Update()
    {
        scoreText.text = "Score : " + score;

        if (!isGameOver)
        {
            surviveTime += Time.deltaTime; // ���� �ð� ����


            timeText.text = "Time : " + (int)surviveTime; // ���� �ð� ǥ��
            scoreText.text = "Score : " + score;

            if (Input.GetKeyDown(KeyCode.R)) // R��ư�� ������
            {
                Restart();                   // �����
            }
        }

        
    }

    public void AddScore() // ���� ����
    {
        score++;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void Reload() // ó�� ȭ��
    {
        SceneManager.LoadScene(0);
    }

    public void ClickExitBtn()
    {
        Application.Quit();
        Debug.Log("���� ����"); 
    }

    // ������ �����ٸ�
    public void EndGame() 
    {
        isGameOver = true;
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);          // ���� ���� �г� ǥ��
        gameOverText.SetActive(true);           // ���� ���� �ؽ�Ʈ ǥ��
        restartBtn.gameObject.SetActive(true);  // ����� ��ư ǥ��
        exitBtn.gameObject.SetActive(true);     // ���� ��ư ǥ��
        bestText.gameObject.SetActive(true);    // �ְ� ���� �ؽ�Ʈ ǥ��

        StartCoroutine(GameOverTextCo());

        // �ְ� ��� ��������
        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f); // �⺻�� 0 ����

        // ���� ������ ������ �ְ� ��Ϻ��� ũ��
        if (score > bestScore)
        {
            // �ְ� ���� ����
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save(); // �����ϱ�
        }

        
        scoreText.text = "Score : " + score;              // ���� ���� �ؽ�Ʈ ǥ��
        bestText.text = "Best Score : " + (int)bestScore; // �ְ� ���� �ؽ�Ʈ ǥ��
    }

    // ���̵� �� ȿ��
    IEnumerator GameOverTextCo()
    {
        if (!gameOverText.TryGetComponent(out TextMeshProUGUI text))
        {
            yield break;
        }

        Color color = text.color;
        color.a = 0.0f;
        text.color = color;
        float alpha = 0.0f;

        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime * 2.0f;
            text.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        text.color = new Color(color.r, color.g, color.b, 1.0f);
    }


}