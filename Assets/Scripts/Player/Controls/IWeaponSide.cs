using System;
using UnityEngine.InputSystem;

public interface IWeaponSide
{
    event Action ChangeWeaponSideAction;

    void ChangeWeaponSide(InputAction.CallbackContext context);
}
