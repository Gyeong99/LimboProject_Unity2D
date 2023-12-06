using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControle : MonoBehaviour
{
    public float lifeTime = 2f;  // 총알의 수명 (초)

    void Start()
    {
        Destroy(gameObject, lifeTime);  // 수명이 다 되면 파괴
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);  // 충돌하면 파괴
        }
        
    }


}
