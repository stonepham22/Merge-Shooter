using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Contains all types of factories in the scene.
/// </summary>
public class FactoryManager : LoboBehaviour
{
    private FactoryManager() { }
    private static Dictionary<ProductType, Factory> _factories = new Dictionary<ProductType, Factory>();

    protected override void LoadComponents()
    {
        LoadFactories();
    }
    void LoadFactories()
    {
        foreach (Factory factory in GetComponentsInChildren<Factory>())
        {
            _factories.TryAdd(factory.GetProductType(), factory);
        }
    }

    /// <summary>
    /// Take a product from the pool if available or create a new one.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    public static async Task<Product> GetProduct(ProductType type, int id)
    {
        Product newProduct = await _factories[type].GetProduct(id);
        return newProduct;
    }

    public static Product GetObjKey(ProductType type, int id)
    {
        return _factories[type].GetObjKey(id);
    }

}
