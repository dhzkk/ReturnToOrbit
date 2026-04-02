using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private PlayerMoveSys _playerMoveSys;
    private PlayerHPSys _playerHPSys;



    private void Awake()
    {
        _playerMoveSys = GetComponent<PlayerMoveSys>();
        _playerHPSys = GetComponent<PlayerHPSys>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Play();
    }

    void Play()
    {
        _playerMoveSys.PlayerMove();
    }
}
