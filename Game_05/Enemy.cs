using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
    }

    public void TakeTarget(Transform target)
    {
        _target = target;
    }
}
