using UnityEngine;

public class PatrolByPoints : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _listPoints;

    private Transform[] _points;
    private int  _currentPoint;

    private void Start()
    {
        _points = new Transform[_listPoints.childCount];

        for (int i = 0; i < _listPoints.childCount; i++)
        { 
            _points[i] = _listPoints.GetChild(i);
        }
    }
    
    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
