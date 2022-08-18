using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform[] _point;
    [SerializeField] float _moveSpeed;
    [SerializeField] int _destPoint;
    NavMeshAgent _navMeshAgent;

    void MovePoint()
    {
        if(_point.Length == 0)
        {
            return;
        }
        _navMeshAgent.destination = _point[_destPoint].position;
        _destPoint = (_destPoint + 1) % _point.Length;
    }
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _moveSpeed;
    }

    void Update()
    {
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
        {
            MovePoint();
        }
    }
}
