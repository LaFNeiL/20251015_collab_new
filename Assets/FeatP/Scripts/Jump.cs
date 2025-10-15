using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("���� �Ŀ�")]
    [SerializeField] private float jumpPower = 8.0f; //���� �Ŀ�

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�Է°� ������ �����޼��� ȣ��
        {
            Jumping();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45.0f), Time.deltaTime * 2f);  //���Ͻ� �Ʒ��� �����
    }

    void Jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower); //�������

        transform.rotation = Quaternion.Euler(0, 0, 30f); //������ ���� �����
    }
}
