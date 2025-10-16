using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    //단순 태그 비교 트리거
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(); //스코어 매니저 에서 AddScore 호출
        }
        //GetScore 오브젝트에 컴포넌트 적용
    }
}
