using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;    

    private void Update()
    {        
        transform.position += Vector3.right * Time.deltaTime * _speed;
    }
}
