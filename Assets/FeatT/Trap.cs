using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("������ Ʈ�� ������")]
    [SerializeField] private GameObject trapPrefab;

    [Header("Ʈ�� ���� �ð� ���� (��)")]
    [SerializeField] private float timeInterval = 1.0f;

    [Header("Ʈ�� ���� �ð� (��)")]
    [SerializeField] private float trapLifetime = 5.0f;

    [Header("Ʈ�� Y�� ���� ����")]
    [SerializeField] private float minY = -0.5f;
    [SerializeField] private float maxY = 1.0f;

    [Header("Ʈ�� ���� X ��ġ")]
    [SerializeField] private float spawnX = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            //��ġ ����
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(spawnX, randomY);

            //Ʈ�� ����
            GameObject newTrap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);

            //���� �ð� �� �ı�
            Destroy(newTrap, trapLifetime);
            timer = 0f;
        }
    }
}
