using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : Factory
{

    public override ProductType GetProductType()
    {
        return ProductType.Monster;
    }
}
