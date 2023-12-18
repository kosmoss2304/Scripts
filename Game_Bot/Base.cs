using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Unit[] _units;
    [SerializeField] private ScannerResource _scannerResource;

    private int _countResources;
    private List<Resource> _foundResources = new List<Resource>();

    private void Update()
    {
        if (_foundResources.Count == 0)
        {
            _foundResources = _scannerResource.SearchFreeResources();
        }

        if (_foundResources.Count > 0)
        {
            if (TryGetFreeUnit(out Unit freeUnit))
            {
                Resource randomResource = _foundResources[UnityEngine.Random.Range(0, _foundResources.Count)];

                randomResource.BecomeTarget();
                freeUnit.SetTarget(randomResource);
                _foundResources.Remove(randomResource);
            }
        }
    }

    public void TakeResource(Resource resource)
    {
        Destroy(resource.gameObject);
        _countResources++;
        Debug.Log("Ресурсов на базе: " + _countResources);
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
}
