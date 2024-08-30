using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunFactory", menuName = "Factory/GunFactory")]
public class GunFactory : ScriptableObject
{
    [SerializeField] private GunFactoryConfig _config;

    public Gun Get(GunType gunType)
    {
        switch(gunType)
        {
            case GunType.Pistol:
                return _config.PistolGunPrefab;

            case GunType.Rifle:
                return _config.RifleGunPrefab;

            //case GunType.Shotgun:
            //return new Shotgun;

            //case GunType.SubmachineGun:
            //return new SubmachineGun;

            default:
                throw new System.ArgumentException(nameof(gunType));
        }
    }
}
