using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : LoboBehaviour
{
    [SerializeField] private Transform _snapPoint;
    [SerializeField] private int _id;

    protected override void LoadComponents()
    {
        _id = GetComponent<Product>().Id;
    }

    void OnEnable()
    {
        foreach(Transform transform in _snapPoint)
        {
            if(transform == this.transform.parent) continue;
            if(transform.childCount == 0) continue;
            Transform child = transform.GetChild(0);
            if(child.gameObject.TryGetComponent<Product>(out Product product) && product.Id == _id)
            {
                
            }
            
        }
    }
}
