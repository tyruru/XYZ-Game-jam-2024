using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkParticalScript : MonoBehaviour
{
    private Walk _walk;
    private CollisionState _collisionState;

    [SerializeField] private GameObject _walkPartical;
    [SerializeField] private Transform _particalTransform;


    private void Awake()
    {
        _walk = GetComponent<Walk>();
        _collisionState = GetComponent<CollisionState>();
    }

    void Update()
    {
        if(_collisionState.standing && _walk.IsWalk)
            if (_walkPartical != null)
                Instantiate(_walkPartical, _particalTransform.position, Quaternion.identity);
    }
}
