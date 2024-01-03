using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Vector2 _moveDirection;
    private float _speed = 5f;

    public void SetMovementDirection(Vector2 direction)
    {
        _moveDirection = direction.normalized;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }
}
