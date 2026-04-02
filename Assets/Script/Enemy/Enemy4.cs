using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : BaseEnemy
{
    protected override void Shoot()
    {
        StartCoroutine(BurstFire());
    }
    IEnumerator BurstFire()
    {
        int burstCount = 3;
        float interval = 0.5f;

        for (int i = 0; i < burstCount; i++)
        {
            Instantiate(_projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
}
