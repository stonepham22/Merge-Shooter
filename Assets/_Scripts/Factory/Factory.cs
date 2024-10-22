using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Factory : LoboBehaviour
{
    [SerializeField] private Transform _prefabParent;
    [SerializeField] private Transform _holder;
    protected Dictionary<int, Product> prefabs = new Dictionary<int, Product>();

    protected override void LoadComponents()
    {
        LoadPrefavParent();
        LoadHolder();
    }
    void LoadPrefavParent()
    {
        if (_prefabParent != null) return;
        _prefabParent = transform.Find("PrefabParent");
    }
    void LoadHolder()
    {
        if (_holder != null) return;
        _holder = transform.Find("Holder");
    }

    public abstract ProductType GetProductType();

    public async Task<Product> GetProduct(int id)
    {
        // Step 1: Check if the product already exists in the prefabs dictionary
        Product productFromDic = GetProductFromDictionary(id);

        if (productFromDic != null)
        {
            Product newProduct = await ObjectPooler.DequeueObject(productFromDic);
            // If the product exists, return an instance of that product
            return newProduct;//Instantiate(productFromDic);
        }
        Debug.Log("no object from dic");
        // Step 2: If the product does not exist, create a new product
        productFromDic = await CreateNewProduct(id);

        // Set up the new product
        SetupProduct(productFromDic, id);

        // Step 3: Return an instance of the new product
        return Instantiate(productFromDic);
    }

    protected virtual Product GetProductFromDictionary(int id)
    {
        if (prefabs.TryGetValue(id, out Product product))
        {
            return product;
        }
        return null;
    }

    /// <summary>
    /// Load the Prefab using Addressables
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected virtual async Task<Product> CreateNewProduct(int id)
    {
        string name = GetProductType().ToString() + "_" + id;
        GameObject prefab = await MyAddressables.LoadAssetAsync(name);
        Product product = prefab.GetComponent<Product>();
        product.gameObject.GetComponent<ScaleWithScreenSize>().Scale();
        return product;
    }

    protected virtual void SetupProduct(Product product, int id)
    {
        if (product == null) return;
        prefabs[id] = product;
        product.transform.SetParent(_holder);
        product.gameObject.SetActive(false);
    }

    public virtual Product GetObjKey(int id)
    {
        return prefabs[id];
    }
}
