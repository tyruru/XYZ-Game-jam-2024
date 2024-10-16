using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractBehaviour : MonoBehaviour
{
    public Buttons[] inputButtons;
    public MonoBehaviour[] disableScripts;

    protected InputState inputState;
    protected Rigidbody2D body2d;
    protected CollisionState collisionState;

    protected virtual void Awake()
    {
        inputState = GetComponent<InputState>();
        body2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    protected virtual void ToggleScript(bool value)
    {
        foreach(var script in disableScripts)
        {
            script.enabled = value;
        }
    }
  
}
