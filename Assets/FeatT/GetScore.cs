using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    //�ܼ� �±� �� Ʈ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //UI�� Score �Լ�ȣ�� ++; �߰��Ұ�.
            //����)Score.score++;
        }
        //�ϼ� �� GetScore ������Ʈ�� ������Ʈ ����
    }
}
