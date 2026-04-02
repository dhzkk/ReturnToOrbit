using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : BaseEnemy
{
    protected override void Shoot()
    {
        Instantiate(_projectile, transform.position, transform.rotation);
    }
}
