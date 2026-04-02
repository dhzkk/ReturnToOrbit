using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : BaseMissile
{
    private float _rotationSpeed;

    private bool isInduction = true;
    protected override void Initialize()
    {
        _rotationSpeed = 2.0f;
        AttackDamage = 15;
        _speed = 15;
    }
    protected override void UpdateMove()
    {
        if (isForcedInduction)
            return;


        Vector3 direction = GameManager.Instance.GetPlayerPosition() - transform.position;
        if (isInduction)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 2f * Time.deltaTime);
            if(Quaternion.Angle(transform.rotation, Quaternion.LookRotation(direction)) > 90)
            {
                isInduction = false;
            }
        }
        else if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(direction)) <= 90)
        {
            isInduction = true;
        }
    }


}
