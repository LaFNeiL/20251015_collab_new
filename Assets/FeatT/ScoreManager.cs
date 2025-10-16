using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //���� ���� �ν��Ͻ� �����

    public int scoreCount = 0; // Ű ������
    public TMP_Text scoreCountText; //���� ���� �ؽ�Ʈ��

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore()
    {
        scoreCount++; //���� ����
        UpdateScoreUI(); //���ھ� ������Ʈ �Լ� ȣ��
    }

    private void UpdateScoreUI() //������ ���ھ� UI ǥ�ÿ�
    {
        if (scoreCountText != null)
            scoreCountText.text = scoreCount.ToString();
    }

}
