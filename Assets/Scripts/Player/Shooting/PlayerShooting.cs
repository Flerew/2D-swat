using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Player))]
public class PlayerShooting : MonoBehaviour
{
    private const float NoShootState = 0f;
    private const float EnableState = 1f;

    private IShoot _controls;
    private Player _player;

    [Inject]
    private void Costruct(PlayerControls playerControls)
    {
        _controls = playerControls;
        _player = GetComponent<Player>();

        _controls.Shoot += Shoot;
        _controls.Reload += Reload;
    }

    private void Update()
    {
        _controls.GetShooting();
    }

    private void OnDisable()
    {
        _controls.Shoot -= Shoot;
        _controls.Reload -= Reload;
    }

    private void Shoot(float shootState)
    {
        if (shootState == EnableState)
            _player.Gun.Shoot();
    }

    private void Reload(float reloadState)
    {
        if(reloadState == EnableState)
            _player.Gun.ReloadMagazine();
    }

}
