using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Contains all types of factories in the scene.
/// </summary>
public class Spawner : LoboBehaviour
{
    private Dictionary<ProductType, Factory> _factories = new Dictionary<ProductType, Factory>();

    protected override void LoadComponents()
    {
        LoadFactories();
    }

    void LoadFactories()
    {
        foreach (Factory factory in GetComponentsInChildren<Factory>())
        {
            _factories.TryAdd(factory.Type, factory);
        }
    }

    /// <summary>
    /// Take a product from the pool if available or create a new one.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    public Product Spawn(ProductType type, int id)
    {
        Product newProduct = _factories[type].GetProduct(id);
        return newProduct;
    }
}
