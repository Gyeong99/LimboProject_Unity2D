using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoom : MonoBehaviour
{
    public GameObject origin;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 0.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(origin);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        // 생성한 총알에 Rigidbody2D 컴포넌트 추가
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletSpawn.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
