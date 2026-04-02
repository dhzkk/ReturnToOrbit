using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : BaseEnemy
{
    [SerializeField] private GameObject _projectile2;

    protected override void Initialize()
    {
        base.Initialize();
        _moveSpeed = 4;
    }
    protected override void Shoot()
    {
        ShootShotgun();
    }

    void ShootShotgun()
    {
        int pelletCount = 5;
        float spreadAngle = 20f;

        for (int i = 0; i < pelletCount; i++)
        {
            float angle = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
            Quaternion rot = Quaternion.Euler(0, angle, 0) * transform.rotation;

            Instantiate(_projectile, transform.position, rot);
        }
        Instantiate(_projectile2 , transform.position, transform.rotation);
    }
}
