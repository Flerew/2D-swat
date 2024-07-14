using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : IMove
{
    public event Action<Vector2> Move;
    public event Action<float> SlowMove;
    public event Action<bool> Fire;

    private PlayerInput _playerInput;

    public PlayerControls(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }

    public void GetMove()
    {
        float slowMoveInput = _playerInput.actions["SlowMove"].ReadValue<float>();
        SlowMove?.Invoke(slowMoveInput);

        Vector2 moveInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        if (moveInput == Vector2.zero)
        {
            Move?.Invoke(Vector2.zero);
        }
        else
        {
            Move?.Invoke(moveInput);
        }
    }
}
