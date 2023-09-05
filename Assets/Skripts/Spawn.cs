using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform[] _enemyWay;
    [SerializeField] private float _coolDown = 2;

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitForSeconds = new WaitForSeconds(_coolDown);

        while (true)
        {
            Enemy enemy =  Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.GetTargetPoint(_targetPoint,_enemyWay);

            yield return waitForSeconds;
        }
    }
}
