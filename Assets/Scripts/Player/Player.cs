using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : Entity
{
    [SerializeField] private Transform _rightGunPosition;
    [SerializeField] private Transform _leftGunPosition;
    [SerializeField] private CameraPoint _cameraPoint;
    [SerializeField] public List<Transform> _viewTriggers;


    private Transform _gunPosition;
    private WeaponSide _weaponSide;
    private Gun _gun;
    private PlayerLoadingData _loadingData;
    private PlayerControls _playerControls;

    private PlayerMovement _movementComponent;
    private PlayerShooting _shootingComponent;
    private PlayerView _viewComponent;
    private PlayerInteract _interactComponent;

    public Gun Gun => _gun;
    public CameraPoint CameraPoint => _cameraPoint;
    public List<Transform> ViewTriggers => _viewTriggers;

    [Inject]
    private void Construct(PlayerLoadingData loadingData, PlayerControls playerControls)
    {
        InitializeComponents();

        _loadingData = loadingData;
        _playerControls = playerControls;

        _gun = _loadingData.PlayerGun;
        _gunPosition = _rightGunPosition;
        _gun = Instantiate(_gun, _gunPosition.position, transform.rotation);
        _gun.Initialize(false);
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

    public void SwitchControls(bool enable)
    {
        _movementComponent.enabled = enable;
        _shootingComponent.enabled = enable;
        _viewComponent.enabled = enable;
        _interactComponent.enabled = enable;
    }

    private void InitializeComponents()
    {
        _movementComponent = GetComponent<PlayerMovement>();
        _shootingComponent = GetComponent<PlayerShooting>();
        _viewComponent = GetComponent<PlayerView>();
        _interactComponent = GetComponent<PlayerInteract>();
        _cameraPoint.Initialize(transform);
    }
}
