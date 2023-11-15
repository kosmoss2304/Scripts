using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    [SerializeField] float _speedScale;
    [SerializeField] Transform _transform;

    private void Update()
    {
        _transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * _speedScale * Time.deltaTime;
    }
}
