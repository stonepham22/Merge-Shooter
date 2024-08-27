using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    private float _damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DamageReceiver>(out var damageReceiver))
        {
            damageReceiver.Receive(_damage);
        }
    }
    
}
