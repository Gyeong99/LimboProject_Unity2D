using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MachinegunFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 0.0f;
    private bool bulletShoot = false;
    private float bulletMax = 12.0f;
    void Update()
    {
        BulletFire();
    }

    void Fire()
    {
        // �Ѿ� �������� �����Ͽ� ����
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        // ������ �Ѿ˿� Rigidbody2D ������Ʈ �߰�
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletSpawn.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void BulletFire()
    {
        if (!bulletShoot)
        {
            return;
        }
        if (bulletShoot)
        {
            // �Ѿ� �������� �����Ͽ� ����
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            // ������ �Ѿ˿� Rigidbody2D ������Ʈ �߰�
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletSpawn.right * bulletSpeed, ForceMode2D.Impulse);
        }
       
        if (bulletMax > 0.0f)
        {
            bulletMax -= 1;
        }
        else
        {
            bulletShoot = false;
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("!!");
            Debug.Log(bulletPrefab.gameObject.name);
            if (bulletPrefab.gameObject.name == "2DLog4")
            {
                Fire();
                Destroy(gameObject);  // �浹�ϸ� �ı�
            }
            else if (bulletPrefab.gameObject.name == "bullet")
            {
                Invoke("Timeasd", 0.8f);
               
                
            }
            else if (bulletPrefab.gameObject.name == "freezeEnemy")
            {
                Fire();
                Destroy(gameObject);  // �浹�ϸ� �ı�
            }
        }


    }

    private void Timeasd()
    {
        if (Time.frameCount % 6 == 0)
        {
            bulletMax = 12.0f;
            bulletShoot = true;
        }
    }
}
