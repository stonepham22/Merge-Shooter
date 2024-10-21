using UnityEngine;
using UnityEngine.AddressableAssets;

public class Product : MonoBehaviour
{
    public int Id { get; private set; }
    public ProductType ProductType{ get; private set; }

    protected virtual void OnDisable()
    {
        // Add to pool
        ObjectPooler.EnqueueObject(this);
    }

}
