using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    //���ӿ��� UI �����;���
    private bool isDead = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return; //�̹� �׾����� ����
        if (collision.gameObject.CompareTag("Pipe") || transform.position.y < -25.0f) //�������� ��ų� �÷��̾ -25.0f���� ���� ��ġ�������� ���� ����
        {
            Died();
        }
    }

    void Died()
    {
        isDead = true;
        //UI������Ʈ ���� �����;���
    }
}
