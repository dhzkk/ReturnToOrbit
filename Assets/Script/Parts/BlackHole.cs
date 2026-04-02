using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : BaseParts
{
    public GameObject Core;

    private void Start()
    {
        Destroy(Core, 5);
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            BaseMissile projectile = other.GetComponent<BaseMissile>();
            projectile.isForcedInduction = true;
            projectile.SetTarget(Core);
        }
    }
}