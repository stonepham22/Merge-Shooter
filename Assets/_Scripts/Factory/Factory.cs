using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : LoboBehaviour
{
    public ProductType Type;
    [SerializeField] private Transform _prefabParent;
    [SerializeField] private Transform _holder;
    private Dictionary<int, Product> prefabs = new Dictionary<int, Product>();

    protected override void LoadComponents()
    {
        LoadPrefavParent();
        LoadPrefab();
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
    void LoadPrefab()
    {
        foreach (Transform transform in _prefabParent)
        {
            Product product = transform.GetComponent<Product>();
            prefabs.TryAdd(product.Id, product);
            product.gameObject.SetActive(false);
        }
    }
    
    public Product GetProduct(int id)
    {
        Product newProduct = ObjectPooler.DequeueObject($"{Type}{id}");
        if (newProduct == null) { newProduct = prefabs[id].Clone(); }
        newProduct.transform.SetParent(_holder);
        return newProduct;
    }

}
