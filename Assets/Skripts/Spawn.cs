using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private float _coolDown = 2;
    private Transform _poit;
    private Transform[] _points;

    private void Start()
    {
        _poit = GetComponent<Transform>();
        _points = new Transform[_poit.childCount];

        for (int i = 0; i < _poit.childCount; i++)
        {
            _points[i] = _poit.GetChild(i);
        }

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitForSeconds = new WaitForSeconds(_coolDown);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_enemy, _points[i].position, Quaternion.identity);

            if (i == _points.Length - 1)
                i = -1;

            yield return waitForSeconds;
        }
    }
}
