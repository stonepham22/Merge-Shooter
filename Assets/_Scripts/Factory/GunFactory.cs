using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GunFactory : Factory
{
    public override ProductType GetProductType()
    {
        return ProductType.Gun;
    }

}
