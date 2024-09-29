using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _rightGunPosition;
    [SerializeField] private Transform _leftGunPosition;

    private Transform _gunPosition;
    private WeaponSide _weaponSide;
    private Gun _gun;
    private PlayerLoadingData _loadingData;
    private PlayerControls _playerControls;

    public Gun Gun => _gun;

    [Inject]
    private void Construct(PlayerLoadingData loadingData, PlayerControls playerControls)
    {
        _loadingData = loadingData;
        _playerControls = playerControls;

        _gun = _loadingData.PlayerGun;
        _gunPosition = _rightGunPosition;
        _gun = Instantiate(_gun, _gunPosition.position, transform.rotation);
        _gun.Initialize();
        _gun.transform.SetParent(transform);

        _weaponSide = new WeaponSide(_playerControls, _gun, _rightGunPosition, _leftGunPosition);
    }

    private void Update()
    {
        _gun.transform.rotation = transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPlayerTrigger trigger))
            trigger.OnPlayerEnter();
    }
}
