using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] protected int id;
    public int Id => id;
    [SerializeField] protected ProductType productType;
    public ProductType ProductType => productType; 

    protected virtual void OnDisable()
    {
        // Add to pool
        Product product = FactoryManager.GetObjKey(productType, id);
        Debug.Log(product.gameObject.GetInstanceID());
        ObjectPooler.EnqueueObject(product, this);
    }

}
