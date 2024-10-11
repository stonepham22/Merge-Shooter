using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : BaseSpawner
{
    [SerializeField] private Lobby _lobby;
    public override async void Spawn(ProductType type, int id)
    {
        Product gun = await ObjectPooler.DequeueObject(type, id);
        gun.transform.localPosition = GetLobby().GetEmptyPosition();
        gun.gameObject.SetActive(true);
    }

    private Lobby GetLobby()
    {
        if (_lobby == null) _lobby = FindAnyObjectByType<Lobby>(); 
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

}
