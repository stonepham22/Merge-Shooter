using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class ObjectPooler
{
    private static Dictionary<GameObject, Queue<Product>> _poolDic = new Dictionary<GameObject, Queue<Product>>();
    
    /// <summary>
    /// Add object to the pool.
    /// </summary>
    public static void EnqueueObject(Product item)
    {
        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(item.gameObject)) { _poolDic.Add(item.gameObject, new Queue<Product>()); }
        
        // Add the object to the pool.
        _poolDic[item.gameObject].Enqueue(item);
    }
    
    /// <summary>
    /// Take an object from the pool if available or create a new one.
    /// </summary>
    public static async Task<Product> DequeueObject(Product item) 
    {
        // If the pool does not contain the object, add it.
        if (!_poolDic.ContainsKey(item.gameObject)) { _poolDic.Add(item.gameObject, new Queue<Product>()); }
    
        // If the pool contains the object, return it.
        if (_poolDic[item.gameObject].TryDequeue(out Product itemPool) && !itemPool.gameObject.activeSelf) 
            { return itemPool; }
    
        // If the pool does not contain the object, create a new one.
        return await CreateNewProduct(item);
    }

    private static async Task<Product> CreateNewProduct(Product item)
    {
        string name = item.ProductType.ToString() + "_" + item.Id;
        GameObject prefab = await MyAddressables.LoadAssetAsync(name);
        Product product = prefab.GetComponent<Product>();
        product.gameObject.GetComponent<ScaleWithScreenSize>().Scale();
        return product;
    }

}
