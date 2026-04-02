using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : BaseEnemy
{
    protected override void Initialize()
    {
        base.Initialize();
        _fireLate = 3;
    }

    protected override void Shoot()
    {
        Instantiate(_projectile, transform.position, transform.rotation);
    }
}