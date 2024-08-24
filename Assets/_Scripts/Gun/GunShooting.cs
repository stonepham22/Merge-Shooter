using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public Spawner spawner;
    void Start()
    {
        InvokeRepeating("Shoot", 1, 0.5f);
    }

    void Shoot()
    {
        Product bullet = spawner.Spawn(ProductType.Bullet, 1);
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
    }
}
