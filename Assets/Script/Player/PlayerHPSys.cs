using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPSys : MonoBehaviour
{
    [SerializeField] private float _playerHP;
    [SerializeField] private float _playerMaxHP;
    [SerializeField] private Slider _hPSlider;

    public bool PlayerIsDead = false;
    public bool isInvincible = false;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {   
        _playerMaxHP = _playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            BaseMissile projectile = other.GetComponent<BaseMissile>();
            TakeDamagePlayer(projectile.AttackDamage);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("IncreaseHP"))
        {
            _playerMaxHP *= 1.1f;
            _playerHP *= 1.1f;
            TakeDamagePlayer(0);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Shield"))
        {
            other.GetComponent<ItemShield>().Use();
        }
        else if (other.CompareTag("ItemHeal"))
        {
            if (_playerHP < _playerMaxHP)
            {
                other.GetComponent<ItemHeal>().Use();
            }
        }
    }

    public void TakeDamagePlayer(float damage)
    {
        if (!isInvincible)
        {
            _playerHP -= damage;
            _hPSlider.value = _playerHP / _playerMaxHP;

            if (_hPSlider.value <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    public void ActivateShield()
    {
        // 이미지 띄우고 
        // 효과 적용하고
        transform.Find("Shield").gameObject.SetActive(true);
        StartCoroutine(Invincible(5));
    }

    IEnumerator Invincible(float time)
    {
        isInvincible = true;
        yield return new WaitForSeconds(time);
        transform.Find("Shield").gameObject.SetActive(false);
        isInvincible = false;
    }
}
