using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //���� ���� �ν��Ͻ� �����

    public int scoreCount = 0; // ����������
    public TMP_Text scoreCountText; //���� ���� �ؽ�Ʈ��

    public int bestScore = 0; // �ְ�������
    public TMP_Text bestScoreText; //�ְ� ���� �ؽ�Ʈ��

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void AddScore()
    {
        scoreCount++; //���� ����
        UpdateScoreUI(); //���ھ� ������Ʈ �Լ� ȣ��

        if (scoreCount > bestScore)
        {
            bestScore = scoreCount;
            PlayerPrefs.SetInt("BestScore", bestScore); //���� ����
            UpdateBestScoreUI();
        }
    }

    private void UpdateScoreUI() //������ ���ھ� UI ǥ�ÿ�
    {
        if (scoreCountText != null)
            scoreCountText.text = scoreCount.ToString();
    }

    private void UpdateBestScoreUI() //����� ����Ʈ ���ھ� UI ǥ�ÿ�
    {
        if (bestScoreText != null)
            bestScoreText.text = bestScore.ToString();
    }

    // ����Ʈ ���ھ� ���


}
