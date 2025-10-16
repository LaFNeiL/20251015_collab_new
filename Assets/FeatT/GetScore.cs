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
            //UI쪽 Score 함수호출 ++; 추가할것.
            //예시)Score.score++;
        }
        //완성 후 GetScore 오브젝트에 컴포넌트 적용
    }
}
