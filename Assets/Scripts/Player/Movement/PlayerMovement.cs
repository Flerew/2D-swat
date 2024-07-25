using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMoveConfig _moveConfig;

    private bool _isSlowMoving;

    private IMove _controls;
    private Rigidbody2D _rb;

    [Inject]
    private void Construct(PlayerControls playerControls)
    {
        _controls = playerControls;
        _rb = GetComponent<Rigidbody2D>();

        _controls.Move += Move;
        _controls.SlowMove += SlowMove;
    }


    private void Update()
    {
        _controls.GetMove();
    }

    private void OnDisable()
    {
        _controls.Move -= Move;
        _controls.SlowMove -= SlowMove;
    }

    private void Move(Vector2 direction)
    {

        float speed = _moveConfig.MoveSpeed;

        if (_isSlowMoving)
            speed = _moveConfig.SlowMoveSpeed;

        if (direction != Vector2.zero)
        {
            if (_rb.velocity.magnitude > speed)
                _rb.velocity = _rb.velocity.normalized * speed;
            else
                _rb.AddForce(direction * speed);
        }
        else
        {
            _rb.velocity *= _moveConfig.Deceleration;
        }

    }

    private void SlowMove(float slowState)
    {
        if(slowState > 0)
            _isSlowMoving = true;
        else
            _isSlowMoving = false;
    }

}
