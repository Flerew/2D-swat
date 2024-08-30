using System;
using UnityEngine.InputSystem;

public interface IWeaponSide
{
    public event Action ChangeWeaponSideAction;

    void ChangeWeaponSide(InputAction.CallbackContext context);
}
