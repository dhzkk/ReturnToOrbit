using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeal : BaseItem
{
    private PlayerHPSys _playerHPSys;
    public override void Use()
    {
        _playerHPSys = GameManager.Instance.GetPlayer().GetComponent<PlayerHPSys>();
        _playerHPSys.TakeDamagePlayer(-20);
        Destroy(gameObject);
    }
}
