using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerControls : IMove, IShoot, ILook, IWeaponSide, IInteract
{
    public event Action<Vector2> Move;
    public event Action<float> SlowMove;
    public event Action<Vector2> Look;
    public event Action<float> OnInteract;
    public event Action<float> Shoot;
    public event Action<float> Reload;
    public event Action ChangeWeaponSideAction;

    private PlayerInput _playerInput;

    private InputAction _changeWeaponSide;

    public PlayerControls(PlayerInput playerInput)
    {
        _playerInput = playerInput;

        _changeWeaponSide = playerInput.actions["WeaponSide"];
        _changeWeaponSide.started += ChangeWeaponSide;
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

    public void GetInteract()
    {
        float interactInput = _playerInput.actions["Interact"].ReadValue<float>();
        OnInteract?.Invoke(interactInput);
    }

    public void GetShooting()
    {
        float shootInput = _playerInput.actions["Fire"].ReadValue<float>();
        Shoot?.Invoke(shootInput);

        float reloadInput = _playerInput.actions["Reload"].ReadValue<float>();
        Reload?.Invoke(reloadInput);
    }

    public void ChangeWeaponSide(InputAction.CallbackContext context)
    {
        ChangeWeaponSideAction?.Invoke();
    }
}
