using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.UI;

public class GunDropdown : MonoBehaviour
{
    public event Action<Gun, int> ChangeGun; // Gun, id

    private GunFactory _gunFactory;
    private Dropdown _dropdown;

    public void Initialize(GunFactory gunFactory, int value = 0) 
    {
        _gunFactory = gunFactory;
        _dropdown = GetComponent<Dropdown>();
        _dropdown.value = value;
    }

    public void OnMenuChoice() // 0-pistol 1-rifle 2-shotgun 3-submachineGun
    {
        int value = _dropdown.value;
        Gun gun;

        switch (value)
        {
            case 0:
                gun = _gunFactory.Get(GunType.Pistol);
                ChangeGun?.Invoke(gun, value);
                break;

            case 1:
                gun = _gunFactory.Get(GunType.Rifle);
                ChangeGun?.Invoke(gun, value);
                break;

            case 2:
                gun = _gunFactory.Get(GunType.Shotgun);
                ChangeGun?.Invoke(gun, value);
                break;

            case 3:
                gun = _gunFactory.Get(GunType.SubmachineGun);
                ChangeGun?.Invoke(gun, value);
                break;

            default:
                throw new System.NullReferenceException(nameof(gun));
        }
    }
}
