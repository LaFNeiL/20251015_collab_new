using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;     // 게임 오버
    [SerializeField] private TextMeshProUGUI timeText;    // 생존시간 텍스트
    [SerializeField] private TextMeshProUGUI scoreText;   // 점수 표시 텍스트
    [SerializeField] private TextMeshProUGUI bestText;    // 최고 기록 표시 텍스트
    [SerializeField] private Button restartBtn;           // 재시작 버튼
    

    private float surviveTime;  // 생존한 시간
    int score = 0; // 점수 누적
    public bool isGameOver = false; // 게임 오버 여부


    void Start()
    {
        Time.timeScale = 1;
        gameOverText.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score : " + score;

        // 게임 오버라면
        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
            restartBtn.gameObject.SetActive(true);

            // 재시작
            Restart();
        }


        // 생존 시간 누적
        surviveTime += Time.deltaTime;
        timeText.text = "Time : " + (int)surviveTime; // 생존 시간 표시

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

    public void Reload() // 재시작
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        isGameOver = true;
        // StartCoroutine(GameOverTextCo());

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

        // 최고 기록 텍스트 표시
        scoreText.text = "Best Score : " + (int)bestScore;
    }

    /****************************************************************************************************
     
    IEnumerator GameOverTextCo()
    {
        // 텍스트 컴포넌트를 못 찾으면 그냥 끝내라
        if (!gameOverText.TryGetComponent(out TextMeshProUGUI text))
        {
            yield break;
        }

        gameOverText.SetActive(true); // 게임 오버 텍스트 오브젝트 활성화

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
    **********************************************************************************************/


 }