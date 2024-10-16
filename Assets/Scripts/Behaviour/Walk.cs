using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Walk : AbstractBehaviour
{
    [SerializeField]
    private float _speed = 0f;
    private bool buttonWalkPressed;

    public bool IsWalk { get; private set; }

    public static event Action OnWalk;

    private void Update()
    {
        var left = inputState.GetButtonValue(inputButtons[0]);
        var right = inputState.GetButtonValue(inputButtons[1]);

        if (right || left || buttonWalkPressed)
        {
            var velx = _speed * (float)inputState.directions;
            body2d.velocity = new Vector2(velx, body2d.velocity.y);
            IsWalk = true;
        }
        else
        {
            IsWalk = false;
        }
    }

    public void WalkSound()
    {
        OnWalk?.Invoke();
    }
}
