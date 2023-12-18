using System.Collections.Generic;
using UnityEngine;

public class ScannerResource : MonoBehaviour
{   
    public List<Resource> SearchFreeResources()
    {
        Collider[] foundObjects = Physics.OverlapSphere(transform.position, 400f);
        List<Resource> foundResources = new List<Resource>();

        foreach (Collider foundObject in foundObjects)
        {
            if (foundObject.TryGetComponent(out Resource resource))
            {
                if (resource.IsTarget == false)
                {
                    foundResources.Add(resource);
                }
            }
        }

        return foundResources;
    }
}
