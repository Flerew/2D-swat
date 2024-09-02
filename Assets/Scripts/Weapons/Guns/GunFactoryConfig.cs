using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GunFactoryConfig
{
    [SerializeField] private Gun _pistolGunPrefab;
    [SerializeField] private Gun _rifleGunPrefab;
    [SerializeField] private Gun _shotgunPrefab;

    public Gun PistolGunPrefab => _pistolGunPrefab;
    public Gun RifleGunPrefab => _rifleGunPrefab;
    public Gun ShotgunPrefab => _shotgunPrefab;
}
