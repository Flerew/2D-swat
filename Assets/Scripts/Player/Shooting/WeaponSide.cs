using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponSide
{
    private IWeaponSide _controls;

    private Transform _rightGunPosition;
    private Transform _leftGunPosition;

    private Gun _gun;


    private bool _side = true; // Right-true Left-false

    public WeaponSide(IWeaponSide controls, Gun gun, Transform rightGunPosition, Transform leftGunPosition)
    {
        _controls = controls;
        _rightGunPosition = rightGunPosition;
        _leftGunPosition = leftGunPosition;
        _gun = gun;

        _controls.ChangeWeaponSideAction += ChangeWeaponSide;
    }

    private void ChangeWeaponSide()
    {
        _side = !_side;

        if (_side == true)
            _gun.transform.position = _rightGunPosition.position;
        else
            _gun.transform.position = _leftGunPosition.position;
    }
}
