using UnityEngine;
using UnityEngine.AddressableAssets;

public class Product : MonoBehaviour
{
    public int Id;
    public ProductType ProductType;
    [SerializeField] private AssetLabelReference obj;
    
    protected virtual void OnDisable()
    {
        // Add to pool
        ObjectPooler.EnqueueObject(this);
    }
    
}
