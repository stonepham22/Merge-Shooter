using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : BaseSpawner
{
    public override void Spawn(int id, FactoryManager factoryManager)
    {
        Product gun = factoryManager.GetProduct(ProductType.Gun, id);
        gun.transform.localPosition = GetRamdomPosition();
        gun.gameObject.SetActive(true);
    }

    private Vector3 GetRamdomPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)];
    }

    protected override void LoadProductType()
    {
        productType = ProductType.Gun;
    }

    protected override void LoadSpawnPoint()
    {
        if(spawnPoint != null) return;
        spawnPoint = GameObject.Find("GunSpawnPoints").GetComponent<RectTransform>();
    }

    protected override void LoadSpawnPositions()
    {
        for (int i = 0; i < spawnPoint.childCount; i++)
        {
            Vector3 worldPosition = UIToWorldPosition.ConvertUIToWorldPosition(spawnPoint.GetChild(i) as RectTransform);
            spawnPositions[i] = worldPosition;
        }
    }

}
