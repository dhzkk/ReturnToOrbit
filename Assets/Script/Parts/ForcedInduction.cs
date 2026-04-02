using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedInduction : MonoBehaviour
{
    private void Start()
    {
        ProjectileManager.Instance.ForcedInduction();
        Destroy(gameObject);
    }
}
