using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Spawner : MonoBehaviour
{     
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _frequencySpawn;
    [SerializeField] private Transform _target;

    private Transform[] _points;

    private void Start()
    {              
        var createEnemyJob = StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            Enemy enemy = Instantiate<Enemy>(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.TakeTarget(_target);

            yield return new WaitForSecondsRealtime(_frequencySpawn);
        }
    }
}

