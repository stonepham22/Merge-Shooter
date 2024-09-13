using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerManager : LoboBehaviour
{
    [SerializeField] private FactoryManager _factoryManager;
    private Dictionary<ProductType, BaseSpawner> _spawners =
        new Dictionary<ProductType, BaseSpawner>();

    [Header("Monster")]
    [SerializeField] private float _monsterSpawnRate = 5f;

    // [Header("Gun")]
    // [SerializeField] private Transform _gunSpawnPoint;

    protected override void LoadComponents()
    {
        LoadFactoryManager();
        LoadSpawner();
    }
    void LoadFactoryManager()
    {
        if (_factoryManager != null) return;
        _factoryManager = FindObjectOfType<FactoryManager>();
    }
    void LoadSpawner()
    {
        if (_spawners.Count > 0) return;
        BaseSpawner[] spawners = GetComponentsInChildren<BaseSpawner>();
        foreach (BaseSpawner spawner in spawners)
        {
            _spawners.Add(spawner.ProductType, spawner);
            Debug.Log($"Spawner {spawner.ProductType} loaded");
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnMonster), 0, _monsterSpawnRate);
    }

    void SpawnMonster()
    {
        Spawn(ProductType.Monster, 1);
    }

    public void Spawn(ProductType type, int id)
    {
        _spawners[type].Spawn(id, _factoryManager);
    }
     
    // void Spawn(GameObject obj, Vector3 position)
    // {
    //     obj.transform.localPosition = position;
    //     obj.SetActive(true);
    // }

    // public void SpawnGun()
    // {
    //     // find empty spawn point
    //     Transform spawnPoint = GetGunSpawnPoint();
    //     if (spawnPoint != null)
    //     {
    //         Product gun = _factoryManager.GetProduct(ProductType.Gun, 1);
    //         gun.gameObject.transform.SetParent(spawnPoint);
    //         Spawn(gun.gameObject, Vector3.zero);
    //     }
    //     else
    //     {
    //         foreach (Transform child in _gunSpawnPoint)
    //         {
    //             if (child.childCount == 0) continue;
    //             if (!child.gameObject.CompareTag("Lobby")) continue;
    //             if (child.GetChild(0).GetComponent<Product>().Id == 1)
    //             {

    //             }
    //         }
    //     }
    // }

    // Transform GetGunSpawnPoint()
    // {
    //     foreach (Transform child in _gunSpawnPoint)
    //     {
    //         if (child.childCount == 0 && child.gameObject.CompareTag("Lobby"))
    //         {
    //             return child;
    //         }
    //     }
    //     return null;
    // }
    // Vector3 GetRamdomPosition()
    // {
    //     int indexSpawnPoint = Random.Range(0, 6);
    //     return _monsterSpawnPositions[indexSpawnPoint];
    // }

}
