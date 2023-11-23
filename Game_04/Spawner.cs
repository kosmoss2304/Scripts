using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [SerializeField] private Transform _allPoint;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _frequencySpawn;

    private Transform[] _points;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_frequencySpawn);
        _points = new Transform[_allPoint.childCount];

        for (int i = 0; i < _allPoint.childCount; i++)
        {
            _points[i] = _allPoint.GetChild(i);
        }

        var createEnemyJob = StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            Transform randomSpawner = _points[Random.Range(0, _points.Length)];

            Enemy enemy = Instantiate(_enemyPrefab, randomSpawner.position, Quaternion.identity);

            yield return _waitForSeconds;
        }
    }
}

