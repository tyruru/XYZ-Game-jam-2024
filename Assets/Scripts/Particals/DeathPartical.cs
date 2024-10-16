using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPartical : MonoBehaviour
{
    [SerializeField] private GameObject _deathPartical;

    bool _stop = false;
    private void OnEnable()
    {
        DeathMenu.OnDeath += StartPartical;
    }

    private void OnDisable()
    {
        DeathMenu.OnDeath -= StartPartical;
    }

    private void StartPartical()
    {
        if (_stop == false)
        {
            Instantiate(_deathPartical, transform.position, Quaternion.identity);
            _stop = true;
        }
    }
}
