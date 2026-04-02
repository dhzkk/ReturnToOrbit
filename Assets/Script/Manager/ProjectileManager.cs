using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance;

    private GameObject _target;
    [SerializeField] private GameObject _targetObject;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ForcedInduction()
    {
        int groundmask = LayerMask.GetMask("Ground");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundmask))
        {
            Debug.Log("맞음");
            Vector3 position = new Vector3(hit.point.x, 0, hit.point.z);
            _target = Instantiate(_targetObject, position, Quaternion.identity);
            Debug.Log(_target);
            
            
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                BaseMissile projectile = transform.GetChild(i).gameObject.GetComponent<BaseMissile>();
                projectile.SetTarget(_target);
                projectile.isForcedInduction = true;
                Debug.Log("타겟 갱신");
            }
        }
    }
}
