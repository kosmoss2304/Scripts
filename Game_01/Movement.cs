using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speedMovement;
    [SerializeField] Transform _transform;

    private void Update()
    {
        _transform.Translate(transform.right * _speedMovement * Time.deltaTime);
    }
}
