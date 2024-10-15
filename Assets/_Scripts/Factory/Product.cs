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
    
    void OnDisable()
    {
        // Add to pool
        ObjectPooler.EnqueueObject(this);

        // Remove to lobby
        LobbyCtrl.SetEmpty(transform.position);

        Observer.Notify(EventType.NotFullLobby, null);
    }
    
}
