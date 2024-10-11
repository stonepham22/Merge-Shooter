using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    // public FactoryManager spawner;
    public bool IsShootingPoint = false;
    [SerializeField] private float _timer;
    [SerializeField] private float _shootInterval = 0.5f;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0.5f, 0);
    
    void FixedUpdate()
    {
        Shoot();
    }

    async void Shoot()
    {
        // If the gun is not shooting, return
        if (!CanShoot()) return;

        // Spawn a bullet and set its position to the gun's position
        Product bullet = await FactoryManager.GetProduct(ProductType.Bullet, 1);
        bullet.transform.position = transform.position + _offset;
        bullet.gameObject.SetActive(true);
    }

    bool CanShoot()
    {
        // If the gun is not at the shooting point, return
        if(!IsShootingPoint) return false;    
        
        // Increment the timer by the fixed delta time
        _timer += Time.fixedDeltaTime;
        
        // If the timer is less than the shoot interval, return false
        if (_timer < _shootInterval) return false;
        
        // Reset the timer and return true
        _timer = 0;
        return true;
    }

}
