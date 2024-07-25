using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerControls : IMove, IShoot, ILook
{
    public event Action<Vector2> Move;
    public event Action<float> SlowMove;
    public event Action<Vector2> Look;
    public event Action<float> Shoot;
    public event Action<float> Reload;

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

    public void GetMobileLook()
    {
        Vector2 lookInput = _playerInput.actions["Look"].ReadValue<Vector2>();
        Look?.Invoke(lookInput);
    }

    public void GetShooting()
    {
        float shootInput = _playerInput.actions["Fire"].ReadValue<float>();
        Shoot?.Invoke(shootInput);

        float reloadInput = _playerInput.actions["Reload"].ReadValue<float>();
        Reload?.Invoke(reloadInput);
    }
}
