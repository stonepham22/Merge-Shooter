using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private FactoryManager _factoryManager;
    [Header("Monster")]
    [SerializeField] private Transform _monsterSpawnPoint;
    [SerializeField] private float _monsterSpawnRate = 5;
    [Header("Gun")]
    [SerializeField] private Transform _gunSpawnPoint;
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnMonster), 0, _monsterSpawnRate);
    }

    void Spawn(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;
        obj.SetActive(true);
    }
    
    public void SpawnGun()
    {
        // find empty spawn point
        Transform spawnPoint = GetGunSpawnPoint();
        if (spawnPoint != null)
        {
            Product gun = _factoryManager.GetProduct(ProductType.Gun, 1);
            gun.gameObject.transform.SetParent(spawnPoint);
            Spawn(gun.gameObject, Vector3.zero);
        }
        else
        {
            foreach (Transform child in _gunSpawnPoint)
            {
                if(child.childCount == 0) continue;
                if(!child.gameObject.CompareTag("Lobby")) continue;
                if(child.GetChild(0).GetComponent<Product>().Id == 1)
                {
                    
                }
            }
        }
    }

    Transform GetGunSpawnPoint()
    {
        foreach (Transform child in _gunSpawnPoint)
        {
            if (child.childCount == 0 && child.gameObject.CompareTag("Lobby"))
            {
                return child;
            }
        }
        return null;
    }

    void SpawnMonster()
    {
        Product monster = _factoryManager.GetProduct(ProductType.Monster, 1);
        Spawn(monster.gameObject, GetRamdomPosition());
    }

    Vector3 GetRamdomPosition()
    {
        int indexSpawnPoint = Random.Range(0, 6);
        return _monsterSpawnPoint.GetChild(indexSpawnPoint).position;
    }

}
