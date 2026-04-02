using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SaveSystem;

public class SkillSlotController : MonoBehaviour
{
    public BaseParts[] _skills;

    [SerializeField] private Image _slot1, _slot2;
    [SerializeField] private Image _slot1CoolTime, _slot2CoolTime;

    private float _coolTime;
    private float _currentCoolTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)) //&& _skills[0].IsAvailable())
        {
            _skills[0].Activate();
           // Time.timeScale = 0;
        }
        if (Input.GetMouseButtonUp(0)) //&& _skills[0].IsAvailable())
        {
            _skills[0].Activate();
            Time.timeScale = 1;
        }

        if (Input.GetMouseButton(1) && _skills[1].IsAvailable())
        {
            Time.timeScale = 0;
        }
        if (Input.GetMouseButtonUp(1) && _skills[1].IsAvailable())
        {
            _skills[1].Activate();
            Time.timeScale = 1;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Key");
        }
    }


}