using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Resource _resourcePrefab;
    [SerializeField] private Transform _ground;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _delay;
    [SerializeField] private float _radius;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        WaitForSecondsRealtime waitForSeconds = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            Bounds boxBounds = _ground.GetComponent<Collider>().bounds;

            Vector3 randomPosition = new Vector3(
                Random.Range(boxBounds.min.x, boxBounds.max.x),
                transform.position.y,
                Random.Range(boxBounds.min.z, boxBounds.max.z));

            Collider[] colliders = Physics.OverlapBox(randomPosition, Vector3.one * _radius, Quaternion.identity, ~_layerMask);

            if (colliders.Length <= 0)
            {            
                Instantiate(_resourcePrefab, randomPosition, Quaternion.identity);
                yield return waitForSeconds;
            }
            else
            { 
                yield return null;
            }
        }
    }
}
