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
        WaitForSeconds _waitForSeconds = new WaitForSeconds(_frequencySpawn);

        while (true)
        {
            Enemy enemy = Instantiate
                (_enemyPrefab, transform.position, Quaternion.identity);
            enemy.SetTarget(_target);

            yield return _waitForSeconds;
        }
    }
}

