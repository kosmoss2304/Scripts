using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class ShootByTarget : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private float _rateFire;
    [SerializeField] private Transform _target;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        var shootByTargetJob = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isShooting = true;

        while (isShooting)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            GameObject bullet = Instantiate(_prefabBullet, _transform.position, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * _speedBullet, ForceMode2D.Impulse);

            yield return new WaitForSecondsRealtime(_rateFire);
        }
    }
}
