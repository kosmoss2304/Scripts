using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private float _speed;

    private Resource _target;   

    public bool HasTarget { get; private set; }
    public bool IsBusy { get; private set; }

    private void Start()
    {
        if (_target == null)
        {
            HasTarget = false;
            IsBusy = false;
        }
    }

    private void Update()
    {
        if (HasTarget && IsBusy)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
        else if (IsBusy)
        {           
            transform.position = Vector3.MoveTowards(transform.position, _base.transform.position, _speed * Time.deltaTime);

            if (transform.position == _base.transform.position)
            {              
                _base.TakeResource(gameObject.GetComponentInChildren<Resource>());
                IsBusy = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Resource resource))
        {
            if (resource != _target)
            {               
                return;
            }
            
            resource.transform.SetParent(transform);
            HasTarget = false;
        }
    }

    public void SetTarget(Resource targetResource)
    { 
        _target = targetResource;
        HasTarget = true;
        IsBusy = true;
    }
}
