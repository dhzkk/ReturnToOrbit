using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpawnSkill : BaseParts
{
    [SerializeField] private GameObject _skillObject;

    public override void Activate()
    {
        base.Activate();
        Vector3 position = GameManager.Instance.GetPlayerPosition();
        Instantiate(_skillObject, new Vector3(position.x, 0, position.z), Quaternion.identity);
    }
}
