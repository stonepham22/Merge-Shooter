using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public static class ObjectPooler
{
    private static Dictionary<string, Queue<Product>> _poolDic = new Dictionary<string, Queue<Product>>();
    public static Dictionary<string, Queue<Product>> PoolDic => _poolDic;
    /// <summary>
    /// Add object to the pool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="name"></param>
    
    // public static void EnqueueObject(Product item, string name)
    public static void EnqueueObject(Product item)
    {
        string name = $"{item.Type}{item.Id}";

        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(name)) { _poolDic.Add(name, new Queue<Product>()); }
        
        // Add the object to the pool.
        _poolDic[name].Enqueue(item);
    }
    
    /// <summary>
    /// Take an object from the pool if available or create a new one.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Product DequeueObject(Product item) 
    {
        string name = $"{item.Type}{item.Id}";
        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(name)) { _poolDic.Add(name, new Queue<Product>()); }

        // If the pool contains the object, return it.
        if (_poolDic[name].TryDequeue(out Product itemPool) && !itemPool.gameObject.activeSelf) 
            { return itemPool; }

        // If the pool does not contain the object, create a new one.
        return item.Clone();
    }

}
