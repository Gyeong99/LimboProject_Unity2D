using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControle : MonoBehaviour
{
    public float lifeTime = 2f;  // �Ѿ��� ���� (��)

    void Start()
    {
        Destroy(gameObject, lifeTime);  // ������ �� �Ǹ� �ı�
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);  // �浹�ϸ� �ı�
        }
        
    }


}
