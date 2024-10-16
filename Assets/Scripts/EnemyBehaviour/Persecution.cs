using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Persecution : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_agent == null)
            _agent = GetComponent<NavMeshAgent>();
        Vector3 pos = new Vector3(_target.position.x, _target.position.y);
        _agent.SetDestination(pos);
    }

}
