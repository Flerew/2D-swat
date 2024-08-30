using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.UI;

public class GunDropdown : MonoBehaviour
{
    public event Action<Gun> ChangeGun;

    private GunFactory _gunFactory;
    private Dropdown _dropdown;

    public void Initialize(GunFactory gunFactory) 
    {
        _gunFactory = gunFactory;
        _dropdown = GetComponent<Dropdown>();
    }

    public void OnMenuChoice() // 0-pistol 1-rifle 2-shotgun
    {
        int value = _dropdown.value;
        Gun gun;

        switch (value)
        {
            case 0:
                gun = _gunFactory.Get(GunType.Pistol);
                ChangeGun?.Invoke(gun);
                break;

            case 1:
                gun = _gunFactory.Get(GunType.Rifle);
                ChangeGun?.Invoke(gun);
                break;

            default:
                throw new System.NullReferenceException(nameof(gun));
        }
    }
}
