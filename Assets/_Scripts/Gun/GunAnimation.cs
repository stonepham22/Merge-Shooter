using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : LoboBehaviour
{
    [SerializeField] private Animator _animator;

    protected override void LoadComponents()
    {
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _animator.Play("Shoot");
    }

    public void Stop()
    {
        _animator.Play("Idle");
    }
}
