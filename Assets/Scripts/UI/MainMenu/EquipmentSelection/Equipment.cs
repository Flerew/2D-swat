using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Equipment : MonoBehaviour
{
    [SerializeField] private GunDropdown _gunDropdown;
    [SerializeField] private GunFactory _gunFactory;

    public Gun Gun { get; private set; }

    [Inject]
    private void Construct()
    {
        _gunDropdown.Initialize(_gunFactory);

        _gunDropdown.ChangeGun += ChangeGun;
        _gunDropdown.OnMenuChoice();
    }

    private void ChangeGun(Gun gun)
    {
        Gun = gun;
    }
}
