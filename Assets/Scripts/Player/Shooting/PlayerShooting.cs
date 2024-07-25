using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Player))]
public class PlayerShooting : MonoBehaviour
{
    private const float NoShootState = 0f;
    private const float ShootState = 1f;

    private IShoot _controls;
    private Player _player;

    [Inject]
    private void Costruct(PlayerControls playerControls)
    {
        _controls = playerControls;
        _player = GetComponent<Player>();

        _controls.Shoot += Shoot;
        _controls.Reload += Reaload;
    }

    private void Update()
    {
        _controls.GetShooting();
    }

    private void OnDisable()
    {
        _controls.Shoot -= Shoot;
        _controls.Reload -= Reaload;
    }

    private void Shoot(float shootState)
    {
        if(shootState == ShootState)
            _player.Gun.Shoot();
    }

    private void Reaload(float reloadState)
    {
        
    }

}
