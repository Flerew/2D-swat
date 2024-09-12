using System;
using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.ComponentModel;

public abstract class Gun : Weapon
{
    public event Action<int, int> AmmoChange; // 1 - Ammo in the magazine 2 - Ammo count

    [SerializeField] private GunConfig _config;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPos;
    [SerializeField] private GameObject _bulletCasing;

    protected bool canShot = true;
    protected bool isEnoughAmmo;
    protected bool isReloading;

    protected float damage;
    protected int ammoCount;
    protected int magazineCapacity;
    protected int ammoCountInMagazine;
    protected float timeBetweenShots;
    protected float reloadTime;
    protected float bulletsSpreads;
    protected float bulletSpeed;
    protected float cameraShake;

    public void Initialize()
    {
        damage = _config.Damage; // isnt using
        ammoCount = _config.AmmoCount;
        magazineCapacity = _config.MagazineCapacity;
        timeBetweenShots = _config.TimeBetweenShots;
        reloadTime = _config.ReloadTime;
        bulletsSpreads = _config.BulletsSpreads;
        bulletSpeed = _config.BulletSpeed;
        cameraShake = _config.CameraShake;

        ammoCount -= 5;

        if (ammoCount > 0)
        {
            isEnoughAmmo = true;

            if (ammoCount < magazineCapacity)
                ammoCountInMagazine = ammoCount;
            else
                ammoCountInMagazine = magazineCapacity;
        }

        ShowAmmoEvent();
    }

    public void ShowAmmoEvent()
    {
        AmmoChange?.Invoke(ammoCountInMagazine, ammoCount);
    }

    public virtual void Shoot()
    {
        _ = ShootAsync();
    }

    public virtual void ReloadMagazine()
    {
        _ = ReloadMagazineAsync();
    }

    protected async UniTaskVoid ShootAsync()
    {
        if (canShot && isEnoughAmmo)
        {
            canShot = false;
            OneShoot();

            ReduceAmmo();

            await UniTask.Delay(TimeSpan.FromSeconds(timeBetweenShots));
            canShot = true;
        }
    }

    protected void OneShoot()
    {
        GameObject bullet = _bulletPrefab.Spawn(_bulletSpawnPos, transform.rotation);

        if (bullet.TryGetComponent(out Bullet component))
        {
            Vector3 direction = transform.up + new Vector3(0, GetRandomSpread(), 0);

            Rigidbody2D bulletRb = component.GetRigidbody();
            bulletRb.AddForce(direction * _config.BulletSpeed, ForceMode2D.Impulse);
        }

        CameraShake.Instance.ShakeCamera(cameraShake);
    }

    protected void ReduceAmmo()
    {
        ammoCountInMagazine--;
        AmmoChange?.Invoke(ammoCountInMagazine, ammoCount);

        if (ammoCountInMagazine <= 0)
            isEnoughAmmo = false;
    }

    private async UniTaskVoid ReloadMagazineAsync()
    {
        if (ammoCount > 0 && isReloading == false)
        {
            isEnoughAmmo = false;
            isReloading = true;

            await UniTask.Delay(TimeSpan.FromSeconds(reloadTime));

            int ammoToFullMagazine = magazineCapacity - ammoCountInMagazine;

            if (ammoCount >= ammoToFullMagazine)
            {
                ammoCount -= ammoToFullMagazine;
                ammoCountInMagazine += ammoToFullMagazine;
            }
            else
            {
                ammoCountInMagazine += ammoCount;
                ammoCount = 0;
            }

            AmmoChange?.Invoke(ammoCountInMagazine, ammoCount);

            isEnoughAmmo = true;
            isReloading = false;
        }
    }

    private float GetRandomSpread()
    {
        float value = UnityEngine.Random.Range(-bulletsSpreads, bulletsSpreads);

        return value;
    }
}
