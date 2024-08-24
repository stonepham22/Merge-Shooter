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
    
    // public static void EnqueueObject<T>(T item, string name) where T : Product
    public static void EnqueueObject(Product item, string name)
    {
        // If the object is not active, return.
        // if (!item.gameObject.activeSelf) { return; }

        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(name)) { _poolDic.Add(name, new Queue<Product>()); }
        
        // Add the object to the pool.
        _poolDic[name].Enqueue(item);
        
        // Deactivate the object.
        // item.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Take an object from the pool if available or create a new one.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    
    // public static T DequeueObject<T>(T item, string name) where T : Product
    public static Product DequeueObject(string name) 
    {
        
        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(name)) { _poolDic.Add(name, new Queue<Product>()); }

        // If the pool contains the object, return it.
        if (_poolDic[name].TryDequeue(out Product item) && !item.gameObject.activeSelf) 
            { return item; }

        // If the pool does not contain the object, return null.
        return null;
    }

}
