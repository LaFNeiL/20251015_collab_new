using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("����ۻ���")]
    [SerializeField] private AudioSource restartSound;

    [Header("����۹�ư")]
    [SerializeField] private Button restartButton;

    [Header("���ӿ��� �ؽ�Ʈ")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("�ְ����� UI")]
    [SerializeField] private GameObject bestScorePanel; // "�ְ�����" �ѱ� UI ��
    [SerializeField] private TMP_Text bestScoreText;    // �ְ� ���� �����Ǵ� ���� ǥ�ÿ�

    void Awake()
    {
        gameOverPanel.SetActive(false); //���ӿ��� �ؽ�Ʈ ��Ȱ��ȭ
        restartButton.gameObject.SetActive(false); //���ӿ��� ��ư ��Ȱ��ȭ
        restartButton.onClick.AddListener(Restart); //��ư Ŭ���� restart�Լ� ȣ��

        bestScorePanel.SetActive(false); //����Ʈ ���ھ� �г� ��Ȱ��ȭ
        bestScoreText.gameObject.SetActive(false); //����Ʈ ���ھ� �������� ��Ȱ��ȭ
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // ���ӿ��� �ؽ�Ʈ Ȱ��ȭ
        restartButton.gameObject.SetActive(true); // ����� ��ư Ȱ��ȭ

        bestScorePanel.SetActive(true); //����Ʈ ���ھ� �г� Ȱ��ȭ

        if (bestScoreText != null)
        {
            bestScoreText.text = ScoreManager.Instance.bestScore.ToString(); // �ְ� ���� ���� ���
            bestScoreText.gameObject.SetActive(true); //����Ʈ ���ھ� �������� Ȱ��ȭ
        }
    }
    public void Restart()
    {
        StartCoroutine(RestartSound());
    }

    private IEnumerator RestartSound()
    {
        restartSound.Play();

        yield return new WaitForSeconds(restartSound.clip.length); //���� ���̸�ŭ ���

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //�� �����
    }
}
