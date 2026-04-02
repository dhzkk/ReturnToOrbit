using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighSpeedBomb : BaseMissile
{

    protected override void Start()
    {
        gameObject.transform.SetParent(GameManager.Instance.GetProjectileManager());
        Invoke("OnCollider", 0.4f);
        Initialize();
    }

    protected override void Initialize()
    {
        AttackDamage = 20;
        _speed = 50.0f;
    }
}
