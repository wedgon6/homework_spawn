using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private Transform _targetPoint;
    private Transform _currentTarget;
    private Transform[] _way;
    private int _currentPoint;

    private void Update()
    {

        if (_currentTarget != _targetPoint)
        {
            _currentTarget = _way[_currentPoint];
            var direction = (_currentTarget.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);

            if (transform.position == _currentTarget.position)
            {
                _currentPoint++;

                if (_currentPoint == _way.Length)
                {
                    _currentTarget = _targetPoint;
                }
            }
        }
        else
        {
            var direction = (_targetPoint.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
        }
    }

    public void GetTargetPoint(Transform point, Transform[] way)
    {
        _targetPoint = point;
        _way = way;
    }
}
