using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("점프 파워")]
    [SerializeField] private float jumpPower = 8.0f; //점프 파워

    [Header("점프사운드")]
    [SerializeField] private AudioSource jumpSound;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //입력값 받으면 점프메서드 호출
        {
            Jumping();
            jumpSound.Play();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45.0f), Time.deltaTime * 2f);  //낙하시 아래로 기울임
    }

    void Jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower); //점프기능

        transform.rotation = Quaternion.Euler(0, 0, 30f); //점프시 위로 기울임
    }
}
