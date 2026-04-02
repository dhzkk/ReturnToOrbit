using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawnSkill : BaseParts
{
    private Vector3 _spwanPosition;

    [SerializeField] private GameObject _skillObject;

    public override void Activate()
    {
        base.Activate();
        int groundMask = LayerMask.GetMask("Ground");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            _spwanPosition = hit.point;
        }
        Instantiate(_skillObject, new Vector3(_spwanPosition.x, 0, _spwanPosition.z), Quaternion.identity);
    }
}
