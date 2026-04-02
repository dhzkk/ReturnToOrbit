using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private Slider _enemyHPSlider;
    [SerializeField] private float _enemyHP;
    [SerializeField] private float _enemyMaxHP;

    [SerializeField] protected GameObject _projectile;
    [SerializeField] protected float _fireLate;

    [SerializeField] protected float _moveSpeed = 5;

    

    
    void Start()
    {
        gameObject.transform.SetParent(GameManager.Instance.GetEnemyGroup());
        StartCoroutine("Fire");
        Initialize();
    }

    
    void Update()
    {
        SetDirection();
        MoveEnemy();
    }
    protected virtual void SetDirection()
    {
        Vector3 direction = GameManager.Instance.GetPlayerPosition() - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 2.0f * Time.deltaTime);
    }

    protected virtual void Initialize()
    {
        _enemyHP = 20;
        _enemyMaxHP = _enemyHP;
    }

    protected virtual IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_fireLate);
        }
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            BaseMissile projectile = other.GetComponent<BaseMissile>();
            TakeDamageEnemy(projectile.AttackDamage);
            Destroy(other.gameObject);
        }
    }

    public virtual void TakeDamageEnemy(float damage)
    {
        _enemyHP -= damage;
        _enemyHPSlider.value = _enemyHP / _enemyMaxHP;

        if(_enemyHPSlider.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void MoveEnemy()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }
}