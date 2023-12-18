using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Unit[] _units;

    private int _countResources;
    private List<Resource> _foundResources = new List<Resource>();

    private void Update()
    {
        if (_foundResources.Count <= 0)
        {
            SearchResources(Physics.OverlapSphere(transform.position, 1000f));
        }

        if (_foundResources.Count > 0)
        {
            if (TryGetFreeResource(out Resource freeResource))
            {
                if (TryGetFreeUnit(out Unit freeUnit))
                {
                    freeResource.BecomeTarget();
                    freeUnit.SetTarget(freeResource);
                    _foundResources.Remove(freeResource);
                }
            }
        }
    }

    public void TakeResource(Resource resource)
    {
        Destroy(resource.gameObject);
        _countResources++;
        Debug.Log("Ресурсов на базе: " + _countResources);
    }

    private void SearchResources(Collider[] foundObjects)
    {
        foreach (Collider foundObject in foundObjects)
        {
            if (foundObject.TryGetComponent(out Resource resource))
            {
                if (resource.IsTarget == false)
                {
                    _foundResources.Add(resource);
                }
            }
        }
    }

    private bool TryGetFreeUnit(out Unit freeUnit)
    {
        freeUnit = null;

        foreach (Unit unit in _units)
        {
            if (unit.IsBusy == false)
            {
                freeUnit = unit;

                return true;
            }
        }

        return false;
    }

    private bool TryGetFreeResource(out Resource freeResource)
    {
        freeResource = null;

        foreach (Resource resource in _foundResources)
        {
            if (resource.IsTarget == false)
            {
                freeResource = resource;

                return true;
            }
        }

        return false;
    }
}
