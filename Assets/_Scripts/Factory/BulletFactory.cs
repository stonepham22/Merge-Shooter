using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : Factory
{

    public override ProductType GetProductType()
    {
        return ProductType.Bullet;
    }
}
