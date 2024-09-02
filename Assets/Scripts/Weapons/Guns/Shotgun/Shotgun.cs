using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private int _bulletsPerShot;

    public override void Shoot()
    {
        _ = ShotgunShoot();
    }

    private async UniTaskVoid ShotgunShoot()
    {
        if (canShot && isEnoughAmmo)
        {
            canShot = false;

            for (int i = 0; i < _bulletsPerShot; i++)
            {
                OneShoot();
            }

            ReduceAmmo();

            await UniTask.Delay(TimeSpan.FromSeconds(timeBetweenShots));
            canShot = true;

        }
    }
}
