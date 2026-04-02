using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy;

    [SerializeField] private Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpwanCoroutine());
    }

    void Update()
    {
        
    }

    private IEnumerator SpwanCoroutine()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(5);
        }
    }

    private void SpawnEnemy()
    {
        int i = Random.Range(0, Enemy.Length);

        int j = Random.Range(0, spawnPoints.Length);

        Instantiate(Enemy[i], spawnPoints[j].position, Quaternion.identity);
    }
}
