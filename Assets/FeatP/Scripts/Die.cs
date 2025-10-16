using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Die : MonoBehaviour
{
    [Header("���ӿ�������")]
    [SerializeField] private AudioSource gameOverBgm;

    [Header("���ӿ����Ŵ���")]
    [SerializeField] private GameOver gameOver;

    [Header("�÷��̾�")]
    [SerializeField] private GameObject player;

    private bool isDead = false;

    private void Update()
    {
        if (transform.position.y < -12.5f || transform.position.y > 10.0f)
        {
            Died();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return; //�̹� �׾����� ����
        if (collision.gameObject.CompareTag("Pipe")) //�������� ��ų� �÷��̾ -15.0f���� ���� ��ġ�������� ���� ����
        {
            Died();
        }
    }

    void Died()
    {
        isDead = true;
        gameOver.ShowGameOver();
        player.SetActive(false); //�÷��̾� ��Ȱ��ȭ
        gameOverBgm.Play();
    }
}
