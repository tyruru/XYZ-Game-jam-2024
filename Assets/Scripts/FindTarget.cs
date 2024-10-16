using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FindTarget : MonoBehaviour
{
    public Vector2 position = Vector2.zero;

    public float collisionRadius = 3f;
    public Color debugCollisionColor = Color.green;

    public LayerMask playerMask;

    private bool isPlayerTouch;

    public static event Action OnPlayerTouch;

    private void FixedUpdate()
    {
        var pos = position;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        isPlayerTouch = Physics2D.OverlapCircle(pos, collisionRadius, playerMask);

        if (isPlayerTouch)
            OnPlayerTouch?.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = debugCollisionColor;

        var positions = new Vector2[] { position };

        foreach (var position in positions)
        {
            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            Gizmos.DrawWireSphere(pos, collisionRadius);
        }
    }
}
