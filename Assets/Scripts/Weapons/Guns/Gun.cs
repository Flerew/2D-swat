using System;
using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

public abstract class Gun : Weapon
{
    public event Action<int, int> AmmoChange; // 1 - Ammo in the magazine 2 - Ammo count

    [SerializeField] private GunConfig _config;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPos;
    [SerializeField] private GameObject _bulletCasing;

    private bool _canShot = true;
    private bool _isEnoughAmmo;
    private bool _isReloading;

    private float _damage;
    private int _ammoCount;
    private int _magazineCapacity;
    private int _ammoCountInMagazine;
    private float _timeBetweenShots;
    private float _reloadTime;
    private float _bulletsSpreads;
    private float _bulletSpeed;

    public void Initialize()
    {
        _damage = _config.Damage; // isnt using
        _ammoCount = _config.AmmoCount;
        _magazineCapacity = _config.MagazineCapacity;
        _timeBetweenShots = _config.TimeBetweenShots;
        _reloadTime = _config.ReloadTime;
        _bulletsSpreads = _config.BulletsSpreads; // isnt using
        _bulletSpeed = _config.BulletSpeed;

        _ammoCount -= 5;

        if (_ammoCount > 0)
        {
            _isEnoughAmmo = true;

            if (_ammoCount < _magazineCapacity)
                _ammoCountInMagazine = _ammoCount;
            else
                _ammoCountInMagazine = _magazineCapacity;
        }

        AmmoChange?.Invoke(_ammoCountInMagazine, _ammoCount);
    }

    public virtual void Shoot()
    {
        TryShoot();
    }

    public virtual void ReloadMagazine()
    {
        _ = ReloadMagazineAsync();
    }

    protected bool TryShoot()
    {
        if (_canShot && _isEnoughAmmo)
        {
            GameObject bullet = _bulletPrefab.Spawn(_bulletSpawnPos, transform.rotation);
            if (bullet.TryGetComponent(out Bullet component))
            {
                Vector3 direction = transform.up;

                Rigidbody2D bulletRb = component.GetRigidbody();
                bulletRb.AddForce(direction * _config.BulletSpeed, ForceMode2D.Impulse);

                ReduceAmmo();
                StartCoroutine(WaitBetweenShots());
            }
            else
            {
                throw new NullReferenceException(bullet.name + "doesn't have Bullet component");
            }


            return true;
        }
        else
        {
            return false;
        }
    }

    protected void ReduceAmmo()
    {
        _ammoCountInMagazine--;
        AmmoChange?.Invoke(_ammoCountInMagazine, _ammoCount);

        if (_ammoCountInMagazine <= 0)
            _isEnoughAmmo = false;
    }

    private async UniTaskVoid ReloadMagazineAsync()
    {
        if (_ammoCount > 0 && _isReloading == false)
        {
            _isEnoughAmmo = false;
            _isReloading = true;

            await UniTask.Delay(TimeSpan.FromSeconds(_reloadTime));

            int ammoToFullMagazine = _magazineCapacity - _ammoCountInMagazine;

            if (_ammoCount >= ammoToFullMagazine)
            {
                _ammoCount -= ammoToFullMagazine;
                _ammoCountInMagazine += ammoToFullMagazine;
            }
            else
            {
                _ammoCountInMagazine += _ammoCount;
                _ammoCount = 0;
            }

            AmmoChange?.Invoke(_ammoCountInMagazine, _ammoCount);

            _isEnoughAmmo = true;
            _isReloading = false;
        }
    }

    private IEnumerator WaitBetweenShots()
    {
        _canShot = false;
        yield return new WaitForSeconds(_timeBetweenShots);
        _canShot = true;
    }
}
