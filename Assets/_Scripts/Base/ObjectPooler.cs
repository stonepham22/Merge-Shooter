using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class ObjectPooler
{
    private static Dictionary<string, Queue<Product>> _poolDic = new Dictionary<string, Queue<Product>>();
    public static Dictionary<string, Queue<Product>> PoolDic => _poolDic;
    
    /// <summary>
    /// Add object to the pool.
    /// </summary>
    public static void EnqueueObject(Product item)
    {
        string name = $"{item.ProductType}{item.Id}";

        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(name)) { _poolDic.Add(name, new Queue<Product>()); }
        
        // Add the object to the pool.
        _poolDic[name].Enqueue(item);
        Debug.Log(_poolDic[name].Count);
    }
    
    /// <summary>
    /// Take an object from the pool if available or create a new one.
    /// </summary>
    public static async Task<Product> DequeueObject(ProductType type, int id) 
    {
        string name = $"{type}{id}";
        
        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(name)) { _poolDic.Add(name, new Queue<Product>()); }
    
        // If the pool contains the object, return it.
        if (_poolDic[name].TryDequeue(out Product itemPool) && !itemPool.gameObject.activeSelf) 
            { return itemPool; }
    
        // If the pool does not contain the object, create a new one.
        return await FactoryManager.GetProduct(type, id);//item.Clone();
    }

}
