using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //전역 접근 인스턴스 저장용

    public int scoreCount = 0; // 점수누적용
    public TMP_Text scoreCountText; //점수 누적 텍스트용

    public int bestScore = 0; // 최고점수용
    public TMP_Text bestScoreText; //최고 점수 텍스트용

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void AddScore()
    {
        scoreCount++; //점수 누적
        UpdateScoreUI(); //스코어 업데이트 함수 호출

        if (scoreCount > bestScore)
        {
            bestScore = scoreCount;
            PlayerPrefs.SetInt("BestScore", bestScore); //점수 저장
            UpdateBestScoreUI();
        }
    }

    private void UpdateScoreUI() //누적된 스코어 UI 표시용
    {
        if (scoreCountText != null)
            scoreCountText.text = scoreCount.ToString();
    }

    private void UpdateBestScoreUI() //저장된 베스트 스코어 UI 표시용
    {
        if (bestScoreText != null)
            bestScoreText.text = bestScore.ToString();
    }

    // 베스트 스코어 기록


}
