using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Death : MonoBehaviour
{
    private void OnEnable()
    {
        DeathMenu.OnDeath += Dead;
    }

    private void OnDisable()
    {
        DeathMenu.OnDeath -= Dead;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

}
