using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGunButton : BaseButton
{
    public SpawnerManager spawnerManager;
    protected override void OnClick()
    {
        spawnerManager.Spawn(ProductType.Gun, 1);
    }

    
}
