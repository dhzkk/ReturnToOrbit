using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSys : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _deceleration;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        
        pos.x = Mathf.Clamp(pos.x, -612.55f, -455.97f);
        pos.z = Mathf.Clamp(pos.z, 321.77f, 436.82f);

        transform.position = pos;
    }

    public void PlayerMove()
    {
        _rotationSpeed = _currentSpeed * 5;

        float rotateInput = 0f;

        if (Input.GetKey("w"))
        {
            _currentSpeed += _acceleration * Time.deltaTime;
        }
        else if (Input.GetKey("s"))
        {
            _currentSpeed -= _deceleration * Time.deltaTime;
        }

        if (Input.GetKey("a")) rotateInput = -10f;
        if (Input.GetKey("d")) rotateInput = 10f;

        transform.Rotate(Vector3.up * rotateInput * _rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * _currentSpeed * _moveSpeed * Time.deltaTime;
        _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _maxSpeed);

    }
}
