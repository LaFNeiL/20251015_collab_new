using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    [Header("Ʈ�� �̵��ӵ�")]
    [SerializeField] private float moveSpeed = 2.0f;

    void Update()
    {
        // ����(-x)���� ���� �ӵ� �̵�
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
