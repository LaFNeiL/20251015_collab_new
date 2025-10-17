using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("재시작사운드")]
    [SerializeField] private AudioSource restartSound;

    [Header("재시작버튼")]
    [SerializeField] private Button restartButton;

    [Header("게임오버 텍스트")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("최고점수 UI")]
    [SerializeField] private GameObject bestScorePanel; // "최고점수" 한글 UI 용
    [SerializeField] private TMP_Text bestScoreText;    // 최고 점수 누적되는 숫자 표시용

    void Awake()
    {
        gameOverPanel.SetActive(false); //게임오버 텍스트 비활성화
        restartButton.gameObject.SetActive(false); //게임오버 버튼 비활성화
        restartButton.onClick.AddListener(Restart); //버튼 클릭시 restart함수 호출

        bestScorePanel.SetActive(false); //베스트 스코어 패널 비활성화
        bestScoreText.gameObject.SetActive(false); //베스트 스코어 누적숫자 비활성화
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // 게임오버 텍스트 활성화
        restartButton.gameObject.SetActive(true); // 재시작 버튼 활성화

        bestScorePanel.SetActive(true); //베스트 스코어 패널 활성화

        if (bestScoreText != null)
        {
            bestScoreText.text = ScoreManager.Instance.bestScore.ToString(); // 최고 점수 숫자 출력
            bestScoreText.gameObject.SetActive(true); //베스트 스코어 누적숫자 활성화
        }
    }
    public void Restart()
    {
        StartCoroutine(RestartSound());
    }

    private IEnumerator RestartSound()
    {
        restartSound.Play();

        yield return new WaitForSeconds(restartSound.clip.length); //사운드 길이만큼 대기

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //씬 재시작
    }
}
