using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public int Id;
    public ProductType Type;
    
    /// <summary>
    /// Creates a clone of the current Product instance.
    /// </summary>
    /// <returns>A new Product instance that is a copy of the current instance.</returns>

    public Product Clone()
    {
        return Instantiate(this);
    }

    void OnDisable()
    {
        ObjectPooler.EnqueueObject(this, $"{Type}{Id}");
    }

    
}
