using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Die : MonoBehaviour
{
    [Header("게임오버사운드")]
    [SerializeField] private AudioSource gameOverBgm;

    [Header("게임오버매니저")]
    [SerializeField] private GameOver gameOver;

    [Header("플레이어")]
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
        if (isDead) return; //이미 죽었으면 무시
        if (collision.gameObject.CompareTag("Pipe")) //파이프에 닿거나 플레이어가 -15.0f보다 낮은 위치에있으면 죽음 판정
        {
            Died();
        }
    }

    void Died()
    {
        isDead = true;
        gameOver.ShowGameOver();
        player.SetActive(false); //플레이어 비활성화
        gameOverBgm.Play();
    }
}
