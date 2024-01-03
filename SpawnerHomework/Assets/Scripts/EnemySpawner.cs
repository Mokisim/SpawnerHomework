using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform[] _points;

    private float _spawnInterval = 2f;
    private float _nextSpawnTime;
    private WaitForSeconds _cooldown;

    private void Awake()
    {
        _points = new Transform[_spawnPoint.childCount];

        for(int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points[i] = _spawnPoint.GetChild(i);
        }

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
        int randomPoint = Random.Range(0, _points.Length);
        Transform randomSpawnpoint = _points[randomPoint];

        _enemyPrefab = Instantiate(_enemyPrefab, randomSpawnpoint.position, Quaternion.identity);

        Vector2 spawnDirection = randomSpawnpoint.position - _spawnPoint.position;
        _enemyPrefab.SetMovementDirection(spawnDirection);
    }
}
