using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPoint;
    
    private float _spawnInterval = 10f;
    private WaitForSeconds _cooldown;

    private void Awake()
    {
        _cooldown = new WaitForSeconds(_spawnInterval);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Spawn();
            yield return _cooldown;
        }
    }

    private void Spawn()
    {
        _enemyPrefab = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);

        _enemyPrefab.SetTarget(_target);
    }
}
