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
            ScoreManager.Instance.AddScore(); //���ھ� �Ŵ��� ���� AddScore ȣ��
        }
        //GetScore ������Ʈ�� ������Ʈ ����
    }
}
