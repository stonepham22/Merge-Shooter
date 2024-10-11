using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawner : LoboBehaviour
{
    [SerializeField] protected ProductType productType;
    public ProductType ProductType => productType;
    [SerializeField] protected RectTransform spawnPoint;
    [SerializeField] protected Vector3[] spawnPositions;

    override protected void LoadComponents()
    {
        LoadProductType();
        LoadSpawnPoint();
        InitSpawnPositions();
        LoadSpawnPositions();
    }
    void Start()
    {
        LoadSpawnPositions();
    }

    protected abstract void LoadProductType();
    protected abstract void LoadSpawnPoint();
    protected void InitSpawnPositions()
    {
        spawnPositions = new Vector3[spawnPoint.childCount];
    }
    protected abstract void LoadSpawnPositions();
    public abstract void Spawn(ProductType type, int id);
}
