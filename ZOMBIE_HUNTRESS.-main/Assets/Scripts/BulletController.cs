using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;

    public float bulletPower = 0f;
    public float lifeTime = 4f;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletPower;

        // Destruye el objeto después de lifeTime segundos
        Invoke("DestroyBullet", lifeTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}