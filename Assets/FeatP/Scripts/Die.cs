using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    //게임오버 UI 가져와야함
    private bool isDead = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return; //이미 죽었으면 무시
        if (collision.gameObject.CompareTag("Pipe") || transform.position.y < -25.0f) //파이프에 닿거나 플레이어가 -25.0f보다 낮은 위치에있으면 죽음 판정
        {
            Died();
        }
    }

    void Died()
    {
        isDead = true;
        //UI오브젝트 실행 가져와야함
    }
}
