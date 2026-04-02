using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BaseMissile : MonoBehaviour
{
    [SerializeField] protected float _speed = 1.0f;
    protected Vector3 _direction;
    public float AttackDamage;
    public bool isForcedInduction = false, isStop = false, isSlow = false;

    [SerializeField] protected GameObject _targetObject;


    [SerializeField] protected Collider _collider;
    [SerializeField] protected Vector3 _currentDirection;
    [SerializeField] protected GameObject _core;
    private void Awake()
    {
        _collider.enabled = false;
    }

    protected virtual void Start()
    {
        _core.SetActive(false);
        gameObject.transform.SetParent(GameManager.Instance.GetProjectileManager());
        Invoke("OnCollider", 1f);
        Initialize();
        _currentDirection = Vector3.forward;
    }

    
    private void Update()
    {
        if (!isStop)
        {
            if(isSlow) transform.Translate(_currentDirection * _speed * 0.5f * Time.deltaTime);
            else transform.Translate(_currentDirection * _speed * Time.deltaTime);
            UpdateMove();
        }
    }
    public void StartTimeStop()
    {
        StartCoroutine(TimeStopCoroutine());
    }
    private IEnumerator TimeStopCoroutine()
    {
        _core.SetActive(true);
        isStop = true;
        yield return new WaitForSeconds(9);
        _core.SetActive(false);
        isStop = false;
    }
    public void Reflex()
    {
        _currentDirection = Vector3.back;
    }

    private void OnCollider()
    {
        _collider.enabled = true;
    }

    protected virtual void Initialize()
    {

    }
    protected virtual void UpdateMove()
    {

    }

    public void SetTarget(GameObject targetObject)
    {
        _targetObject = targetObject;
        transform.rotation = Quaternion.LookRotation(_targetObject.transform.position - transform.position);
        _currentDirection = Vector3.forward;
    }
}
