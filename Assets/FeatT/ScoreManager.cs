using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //전역 접근 인스턴스 저장용

    public int scoreCount = 0; // 키 누적용
    public TMP_Text scoreCountText; //점수 누적 텍스트용

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore()
    {
        scoreCount++; //점수 누적
        UpdateScoreUI(); //스코어 업데이트 함수 호출
    }

    private void UpdateScoreUI() //누적된 스코어 UI 표시용
    {
        if (scoreCountText != null)
            scoreCountText.text = scoreCount.ToString();
    }

}
