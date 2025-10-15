using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    [Header("트랩 이동속도")]
    [SerializeField] private float moveSpeed = 2.0f;

    void Update()
    {
        // 왼쪽(left)으로 일정 속도 이동
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
