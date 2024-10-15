using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Product : MonoBehaviour
{
    public int Id;
    public ProductType ProductType;
    [SerializeField] private AssetLabelReference obj;
    
    /// <summary>
    /// </summary>
    /// <returns>A new Product instance that is a copy of the current instance.</returns>

    // public Product Clone()
    // {
    //     var handle = Addressables.LoadAssetAsync<GameObject>(obj);
    //     handle.Completed += (AsyncOperationHandle<GameObject> task) =>
    //     {
    //         return Instantiate(task.Result);
    //     };
    //     return Instantiate(this);
    // }

    void OnDisable()
    {
        // Add to pool
        ObjectPooler.EnqueueObject(this);

        // Remove to lobby
        LobbyCtrl.SetEmpty(transform.position);

        Observer.Notify(EventType.NotFullLobby, null);
    }
    
}
