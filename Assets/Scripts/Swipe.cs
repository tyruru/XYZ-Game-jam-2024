using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Swipe : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private InputManager _generalInputManager;
    [SerializeField] private MonoBehaviour _generalCharacter;
    private Persecution _generalPersecution;
    private NavMeshAgent _generalAgent;
    private LongJump _generalJump;
    private Walk _generalWalk;
    private IsGost _generalGost;

    [Header("Second")]
    [SerializeField] private InputManager _secondInputManager;
    [SerializeField] private MonoBehaviour _secondCharacter;
    private Persecution _secondPersecution;
    private NavMeshAgent _secondAgent;
    private LongJump _secondJump;
    private Walk _secondWalk;
    private IsGost _secondGost;

    private void Awake()
    {
        _generalInputManager.enabled = true;
        _generalPersecution = _generalCharacter.GetComponent<Persecution>();
        _generalAgent = _generalCharacter.GetComponent<NavMeshAgent>();
        _generalJump = _generalCharacter.GetComponent<LongJump>();
        _generalWalk = _generalCharacter.GetComponent<Walk>();
        _generalGost = _generalCharacter.GetComponent<IsGost>();
        _generalPersecution.enabled = false;
        _generalAgent.enabled = false;
        _generalJump.enabled = true;
        _generalWalk.enabled = true;
        _generalGost.Gost = false;

        _secondInputManager.enabled = false;
        _secondPersecution = _secondCharacter.GetComponent<Persecution>();
        _secondAgent = _secondCharacter.GetComponent<NavMeshAgent>();
        _secondJump = _secondCharacter.GetComponent<LongJump>();
        _secondWalk = _secondCharacter.GetComponent<Walk>();
        _secondGost = _secondCharacter.GetComponent<IsGost>();
        _secondPersecution.enabled = true;
        _secondAgent.enabled = true;
        _secondJump.enabled = false;
        _secondWalk.enabled = false;
        _secondGost.Gost = true;

        Timer.OnTimerOut += DoSwipe;
    }

    private void DoSwipe()
    {
        _generalInputManager.enabled = !_generalInputManager.enabled;
        _generalPersecution.enabled = !_generalPersecution.enabled;
        if (!_generalAgent.enabled)
        {
            _generalCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        _generalAgent.enabled = !_generalAgent.enabled;
        _generalWalk.enabled = !_generalWalk.enabled;
        _generalJump.enabled = !_generalJump.enabled;
        _generalGost.Gost = !_generalGost.Gost;


        _secondInputManager.enabled = !_secondInputManager.enabled;
        _secondPersecution.enabled = !_secondPersecution.enabled;
        if (!_secondAgent.enabled)
            _secondCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _secondAgent.enabled = !_secondAgent.enabled;
        _secondWalk.enabled = !_secondWalk.enabled;
        _secondJump.enabled = !_secondJump.enabled;
        _secondGost.Gost = !_secondGost.Gost;
            
    }

    private void OnDisable()
    {
        Timer.OnTimerOut -= DoSwipe;
    }
}
