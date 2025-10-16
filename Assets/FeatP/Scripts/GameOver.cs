using System.Collections;
using System.Collections.Generic;
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

    void Awake()
    {
        gameOverPanel.SetActive(false); //게임오버 텍스트 비활성화
        restartButton.gameObject.SetActive(false); //게임오버 버튼 비활성화
        restartButton.onClick.AddListener(Restart); //버튼 클릭시 restart함수 호출
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // 게임오버 텍스트 활성화
        restartButton.gameObject.SetActive(true); // 재시작 버튼 활성화
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
