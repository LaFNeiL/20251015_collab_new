using System.Collections;
using System.Collections.Generic;
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

    void Awake()
    {
        gameOverPanel.SetActive(false); //���ӿ��� �ؽ�Ʈ ��Ȱ��ȭ
        restartButton.gameObject.SetActive(false); //���ӿ��� ��ư ��Ȱ��ȭ
        restartButton.onClick.AddListener(Restart); //��ư Ŭ���� restart�Լ� ȣ��
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // ���ӿ��� �ؽ�Ʈ Ȱ��ȭ
        restartButton.gameObject.SetActive(true); // ����� ��ư Ȱ��ȭ
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
