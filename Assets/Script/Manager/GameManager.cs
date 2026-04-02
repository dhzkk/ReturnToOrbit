using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveSystem;
using static StatsSaveSystem;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    public Transform projectileManager;
    public Transform enemyGroup;

    public bool isStoped = false;

    private SaveData _saveData;
    private StatsSaveData _statsData;

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _gameOverPanel;

    public bool IsStop = false;

    private void Awake()
    {
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

    public Vector3 GetPlayerPosition()
    {
        return _player.transform.position;
    }
    public Player GetPlayer() => _player;
    public void GameOver()
    {
        PlayerHPSys playerHPSys = GetComponent<PlayerHPSys>();
        _gameOverPanel.SetActive(true);
    }

    public Transform GetProjectileManager() => projectileManager;

    public Transform GetEnemyGroup() => enemyGroup;

    public void IncreaseSkillActivateCount() => _statsData.SkillActivateCount++;
}
