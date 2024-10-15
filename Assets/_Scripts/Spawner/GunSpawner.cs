using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : BaseSpawner, IObserver
{
    [SerializeField] private bool _isFullLobby;
    List<EventType> _events = new List<EventType>() { EventType.FullLobby, EventType.NotFullLobby };


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
        Product gun = await ObjectPooler.DequeueObject(type, id);
        gun.transform.localPosition = LobbyCtrl.GetEmptyPosition();
        if (_isFullLobby) return;
        gun.gameObject.SetActive(true);
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
