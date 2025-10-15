using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("게임 패널")]
    [SerializeField] private GameObject gameOverPanel;    // 어두운 배경 패널
    [Header("게임 텍스트")]
    [SerializeField] private GameObject gameOverText;     // 게임 오버 텍스트
    [SerializeField] private TextMeshProUGUI timeText;    // 생존 시간 텍스트
    [SerializeField] private TextMeshProUGUI scoreText;   // 현재 점수 표시 텍스트
    [SerializeField] private TextMeshProUGUI bestText;    // 최고 점수 표시 텍스트
    [Header("게임 버튼")]
    [SerializeField] private Button restartBtn;           // 재시작 버튼
    [SerializeField] private Button exitBtn;              // 종료 버튼


    private float surviveTime;  // 생존한 시간
    private int score = 0; // 점수 누적
    [Header("게임 종료 여부")]
    public bool isGameOver = false; // 게임 오버 여부


    void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);         // 게임 오버 패널 숨김
        gameOverText.SetActive(false);          // 게임 오버 텍스트 숨김
        restartBtn.gameObject.SetActive(false); // 재시작 버튼 숨김
        exitBtn.gameObject.SetActive(false);    // 종료 버튼 숨김
        bestText.gameObject.SetActive(false);   // 최고 점수 텍스트 숨김
    }

    void Update()
    {
        scoreText.text = "Score : " + score;

        if (!isGameOver)
        {
            surviveTime += Time.deltaTime; // 생존 시간 누적


            timeText.text = "Time : " + (int)surviveTime; // 생존 시간 표시
            scoreText.text = "Score : " + score;

            if (Input.GetKeyDown(KeyCode.R)) // R버튼을 누르면
            {
                Restart();                   // 재시작
            }
        }

        
    }

    public void AddScore() // 점수 누적
    {
        score++;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void Reload() // 처음 화면
    {
        SceneManager.LoadScene(0);
    }

    public void ClickExitBtn()
    {
        Application.Quit();
        Debug.Log("게임 종료"); 
    }

    // 게임이 끝났다면
    public void EndGame() 
    {
        isGameOver = true;
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);          // 게임 오버 패널 표시
        gameOverText.SetActive(true);           // 게임 오버 텍스트 표시
        restartBtn.gameObject.SetActive(true);  // 재시작 버튼 표시
        exitBtn.gameObject.SetActive(true);     // 종료 버튼 표시
        bestText.gameObject.SetActive(true);    // 최고 점수 텍스트 표시

        StartCoroutine(GameOverTextCo());

        // 최고 기록 가져오기
        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f); // 기본값 0 설정

        // 현재 점수가 이전의 최고 기록보다 크면
        if (score > bestScore)
        {
            // 최고 점수 갱신
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save(); // 저장하기
        }

        
        scoreText.text = "Score : " + score;              // 현재 점수 텍스트 표시
        bestText.text = "Best Score : " + (int)bestScore; // 최고 점수 텍스트 표시
    }

    // 페이드 인 효과
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