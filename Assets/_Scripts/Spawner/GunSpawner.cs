using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : BaseSpawner, IObserver
{
    [SerializeField] private LobbyManager _lobby;
    [SerializeField] private bool _isFullLobby;

    private void OnEnable()
    {
        Observer.Regist(Type.FullLobby, this);
    }
    private void OnDisable()
    {
        Observer.Unregist(Type.FullLobby, this);
    }
    private void OnDestroy()
    {
        Observer.Unregist(Type.FullLobby, this);
    }

    public override async void Spawn(ProductType type, int id)
    {
        if(_isFullLobby) return;
        Product gun = await ObjectPooler.DequeueObject(type, id);
        // gun.transform.localPosition = GetLobby().GetEmptyPosition();
        gun.transform.localPosition = LobbyCtrl.GetEmptyPosition();
        if(_isFullLobby) return;
        gun.gameObject.SetActive(true);
    }

    private LobbyManager GetLobby()
    {
        if (_lobby == null) _lobby = FindAnyObjectByType<LobbyManager>(); 
        return _lobby;
    }

    protected override void LoadProductType()
    {
        productType = ProductType.Gun;
    }

    protected override void LoadSpawnPoint()
    {
        if(spawnPoint != null) return;
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

    public void Notify(Type type, object data)
    {
        _isFullLobby = true;
    }
}
