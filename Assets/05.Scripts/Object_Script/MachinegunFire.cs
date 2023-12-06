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
        // 총알 프리팹을 복제하여 생성
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        // 생성한 총알에 Rigidbody2D 컴포넌트 추가
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
            // 총알 프리팹을 복제하여 생성
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            // 생성한 총알에 Rigidbody2D 컴포넌트 추가
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
                Destroy(gameObject);  // 충돌하면 파괴
            }
            else if (bulletPrefab.gameObject.name == "bullet")
            {
                Invoke("Timeasd", 0.8f);
               
                
            }
            else if (bulletPrefab.gameObject.name == "freezeEnemy")
            {
                Fire();
                Destroy(gameObject);  // 충돌하면 파괴
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
