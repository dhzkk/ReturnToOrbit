using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMissile : BaseMissile
{
    protected override void Initialize()
    {
        AttackDamage = 5;
        _speed = 20;
    }
}
