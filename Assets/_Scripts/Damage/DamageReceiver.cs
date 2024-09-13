using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private float _maxHp = 2;
    [SerializeField] private float _hp = 1;
    

    void OnEnable()
    {
        _hp = _maxHp;
    }

    public virtual void Receive(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Dead();
        }
    }
    protected virtual void Dead()
    {
        transform.gameObject.SetActive(false);
    }

}
