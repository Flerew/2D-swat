using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;

    private Gun _gun;
    private PlayerLoadingData _loadingData;

    public Gun Gun => _gun;

    [Inject]
    private void Construct(PlayerLoadingData loadingData)
    {
        _loadingData = loadingData;

        _gun = _loadingData.PlayerGun;
        _gun = Instantiate(_gun, _gunPosition.position, transform.rotation);
        _gun.Initialize();
        _gun.transform.SetParent(transform);
    }

    private void Update()
    {
        _gun.transform.position = _gunPosition.position;
        _gun.transform.rotation = transform.rotation;
    }
}
