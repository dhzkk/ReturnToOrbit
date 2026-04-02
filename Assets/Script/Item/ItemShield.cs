using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class ItemShield : BaseItem
{
    private PlayerHPSys _playerHPSys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        _playerHPSys = GameManager.Instance.GetPlayer().GetComponent<PlayerHPSys>();
        _playerHPSys.ActivateShield();
        Destroy(gameObject);
    }

}