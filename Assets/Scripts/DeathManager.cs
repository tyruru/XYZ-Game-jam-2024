using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class DeathManager : MonoBehaviour
{
    public DeathMenu deathMenu;

    public bool IsDead { get; private set; }

    public static Action OnHeroDead;


    private void Start()
    {
        IsDead = false;
        //FindTarget.OnPlayerTouch += OnDeath;

    }

    public void OnDeath()
    {
        //_generalAgent = _generalCharacter.GetComponent<NavMeshAgent>();
        //_secondAgent = _secondCharacter.GetComponent<NavMeshAgent>();

        //if (IsDead == false) OnHeroDead?.Invoke();

        //IsDead = true;

        ////_swipe.enabled = false;

        //if (!_generalAgent.enabled)
        //{
        //    Death death = _generalCharacter.GetComponent<Death>();
        //    death.OnDeath();
        //}

        //if (!_secondAgent.enabled)
        //{
        //    Death death = _secondCharacter.GetComponent<Death>();
        //    death.OnDeath();
        //}
        Debug.Log("Wokr");

        DeathMenu();
    }


    public void DeathMenu()
    {
        deathMenu.LoseGame();
    }

}
