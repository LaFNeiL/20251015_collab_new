using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("스폰할 트랩 프리팹 할당")]
    [SerializeField] private GameObject trapPrefab;

    [Header("트랩 생성 시간 간격 (초)")]
    [SerializeField] private float timeInterval = 1.0f;

    [Header("트랩 유지 시간 (초)")]
    [SerializeField] private float trapLifetime = 5.0f;

    [Header("트랩 Y축 랜덤 범위")]
    [SerializeField] private float minY = -0.5f;
    [SerializeField] private float maxY = 1.0f;

    [Header("트랩 고정 X 위치->스폰되는 위치")]
    [SerializeField] private float spawnX = 5.0f;

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            //위치 설정
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(spawnX, randomY);

            //트랩 생성
            GameObject newTrap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);

            //일정 시간 후 파괴
            Destroy(newTrap, trapLifetime);
            timer = 0.0f;
        }
    }
}
