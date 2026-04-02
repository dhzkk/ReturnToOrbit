using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Howitzer : BaseMissile
{
    private Vector3 _startPos;
    private Vector3 _targetOriginPos;
    private Vector3 _targetPos;

    [SerializeField] private float _arcHeight = 1.0f;
    [SerializeField] private float _progress;

    [SerializeField] private GameObject _targetIndicator;

    private float _targetErrorRange = 10;

    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _explosionRadius = 10.0f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_targetPos, _explosionRadius);
    }

    protected override void Initialize()
    {
        AttackDamage = 25;
        _arcHeight = 10;

        _startPos = transform.position;

        _targetOriginPos = GameManager.Instance.GetPlayerPosition();

        Vector2 randomOffset = Random.insideUnitCircle * _targetErrorRange;

        _targetPos = new Vector3(_targetOriginPos.x + randomOffset.x, _targetOriginPos.y, _targetOriginPos.z + randomOffset.y);

        Vector3 indicatorPos = _targetPos;
        indicatorPos.y -= 1f;

        _targetIndicator = Instantiate(_targetIndicator, indicatorPos, Quaternion.identity);
    }

    protected override void UpdateMove()
    {
        if (isForcedInduction)
        {
            Redirection();
        }

            
        if (_progress >= 1f)
        {
            Explode();

        }
        else
        {
            _progress += Time.deltaTime * _speed;
            Vector3 Pos = Vector3.Lerp(_startPos, _targetPos, _progress);
            Pos.y += _arcHeight * 4 * (_progress - _progress * _progress);

            transform.position = Pos;
        }

    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in hits)
        {
            PlayerHPSys hp = hit.GetComponent<PlayerHPSys>();
            if (hp != null)
            {
                hp.TakeDamagePlayer(AttackDamage);
            }

            BaseEnemy enemy = hit.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamageEnemy(AttackDamage);
            }
        }

        if (_targetIndicator != null)
        {
            Destroy(_targetIndicator);
        }
        Destroy(gameObject);
    }

    private void Redirection()
    {
        _startPos = transform.position;
        _targetPos = _targetObject.transform.position;
        _progress = 0;

        if (_targetIndicator != null)
        {
            Vector3 indicatorPos = _targetPos;
            indicatorPos.y -= 1f;
            _targetIndicator.transform.position = indicatorPos;
        }

        isForcedInduction = false;
    }
}