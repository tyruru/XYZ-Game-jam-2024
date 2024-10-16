using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionState : MonoBehaviour
{
    public LayerMask collisionLayer;
    public bool standing;
    public Vector2 bottomPosition = Vector2.zero;

    public float collisionRadius = 10f;
    public Color debugCollisionColor = Color.red;

    public static event Action OnLanded;

    private bool _onAir = false;

    private void FixedUpdate()
    {
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);

        if (!standing)
            _onAir = true;

        if (standing && _onAir)
        {
            _onAir = false;
            OnLanded?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = debugCollisionColor;

        var positions = new Vector2[]{bottomPosition};

        foreach (var position in positions)
        {
            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            Gizmos.DrawWireSphere(pos, collisionRadius);
        }
    }
}
