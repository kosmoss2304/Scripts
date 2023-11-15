using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _speedRotation;
    
    private void Update()
    {       
        _transform.eulerAngles += new Vector3(0, 10, 0) * _speedRotation * Time.deltaTime;
    }
}
