using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : BaseSpawner
{
    private float _offset = 1f; // Offset from the top of the screen

    public override void Spawn(int id, FactoryManager factoryManager)
    {
        Product monster = factoryManager.GetProduct(ProductType.Monster, id);
        monster.transform.position = GetRamdomPosition();
        monster.gameObject.SetActive(true);
    }
    private Vector3 GetRamdomPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)];
    }
    protected override void LoadProductType()
    {
        productType = ProductType.Monster;
    }
    protected override void LoadSpawnPoint()
    {
        if(spawnPoint != null) return;
        spawnPoint = GameObject.Find("MonsterSpawnPoints").GetComponent<RectTransform>();
    }
    protected override void LoadSpawnPositions()
    {
        for (int i = 0; i < spawnPoint.childCount; i++)
        {
            Vector3 worldPosition = MyCalculator.ConvertUIToWorldPosition(spawnPoint.GetChild(i) as RectTransform);
            worldPosition = MyCalculator.GetPositionOverScreen(worldPosition, _offset);
            spawnPositions[i] = worldPosition;
        }
    }

}
