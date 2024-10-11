using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerManager : LoboBehaviour
{
    // [SerializeField] private FactoryManager _factoryManager;
    private Dictionary<ProductType, BaseSpawner> _spawners =
        new Dictionary<ProductType, BaseSpawner>();

    [Header("Monster")]
    [SerializeField] private float _monsterSpawnRate = 5f;

    protected override void LoadComponents()
    {
        // LoadFactoryManager();
        LoadSpawner();
    }
    // void LoadFactoryManager()
    // {
    //     if (_factoryManager != null) return;
    //     _factoryManager = FindObjectOfType<FactoryManager>();
    // }
    void LoadSpawner()
    {
        if (_spawners.Count > 0) return;
        BaseSpawner[] spawners = GetComponentsInChildren<BaseSpawner>();
        foreach (BaseSpawner spawner in spawners)
        {
            _spawners.Add(spawner.ProductType, spawner);
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnMonster), 1, _monsterSpawnRate);
    }

    void SpawnMonster()
    {
        Spawn(ProductType.Monster, 1);
    }

    public void Spawn(ProductType type, int id)
    {
        _spawners[type].Spawn(type, id);
    }

}
