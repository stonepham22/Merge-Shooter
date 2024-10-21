using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : BaseSpawner, IObserver
{
    [SerializeField] private bool _isFullLobby;
    List<EventType> _events = new List<EventType>()
        { EventType.FullLobby, EventType.NotFullLobby };
    
    // Check Merge Gun
    private Dictionary<int, Gun> _guns = new Dictionary<int, Gun>();

    // Prefab to spawn
    private Dictionary<int, GameObject> _gunPrefabs = new Dictionary<int, GameObject>();

    private void OnEnable()
    {
        Observer.Regist(_events, this);
    }
    private void OnDisable()
    {
        Observer.Unregist(_events, this);
    }

    public override async void Spawn(ProductType type, int id)
    {
        if (_isFullLobby) return;
        Product newProduct = await FactoryManager.GetProduct(type,id);
        newProduct.transform.localPosition = LobbyCtrl.GetEmptyPosition();
        if (_isFullLobby) return;
        newProduct.gameObject.SetActive(true);
        // CheckMerge(newProduct);
    }

    private void CheckMerge(Product gun)
    {
        if (_guns.ContainsKey(gun.Id))
        {
            // Disable two guns
            gun.gameObject.SetActive(false);
            _guns[gun.Id].gameObject.SetActive(false);
            _guns.Remove(gun.Id);
            // Spawn a new gun
        }
        else
        {
            _guns.Add(gun.Id, (Gun)gun);
        }
    }

    protected override void LoadProductType()
    {
        productType = ProductType.Gun;
    }

    protected override void LoadSpawnPoint()
    {
        if (spawnPoint != null) return;
        spawnPoint = GameObject.Find("Lobby").GetComponent<RectTransform>();
    }

    protected override void LoadSpawnPositions()
    {
        for (int i = 0; i < spawnPoint.childCount; i++)
        {
            Vector3 worldPosition = MyCalculator.ConvertUIToWorldPosition(spawnPoint.GetChild(i) as RectTransform);
            spawnPositions[i] = worldPosition;
        }
    }

    /// <summary>
    /// Notify the observer of the event.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="data"></param>
    public void Notify(EventType type, object data)
    {
        switch (type)
        {
            case EventType.FullLobby:
                _isFullLobby = true;
                break;
            case EventType.NotFullLobby:
                _isFullLobby = false;
                break;
        }

    }
}
