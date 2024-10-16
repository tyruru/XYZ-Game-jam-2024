using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jump : AbstractBehaviour
{
    public float jumpSpeed = 13f;
    public float jumpDelay = .1f;
    public int jumpCount = 2;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;

    private float time = 1;

    public static event Action OnJumped;

    protected virtual void  Update()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (collisionState.standing)
        {
            jumpsRemaining = jumpCount;
            if (canJump && holdTime < .1f)
            {            
                OnJump();
                jumpsRemaining--;
            }
        }
        else
        {
            if(canJump && holdTime < .1f && Time.time - lastJumpTime > jumpDelay)
            {
                if(jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining--;
                }
            }
        }
      
    }

    protected virtual void OnJump()
    {
        var vel = body2d.velocity;
        lastJumpTime = Time.time;
        body2d.velocity = new Vector2(vel.x, jumpSpeed);

        if (Time.time - time > .12f)
        {
            OnJumped?.Invoke();
            time = Time.time;
        }
    }

}
