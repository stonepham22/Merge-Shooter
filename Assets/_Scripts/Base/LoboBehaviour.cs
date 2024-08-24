using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoboBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        // ResetValue();
        LoadComponents();
    }

    protected virtual void Awake()
    {
        LoadComponents();
    }
    protected abstract void LoadComponents();
    // protected virtual void ResetValue() { }
}
