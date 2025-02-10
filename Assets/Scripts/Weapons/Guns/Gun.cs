using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public abstract class Gun : Weapon, IGun
{
    public event Action<int, int> AmmoChange; // 1 - Ammo in the magazine 2 - Ammo count
    public event Action OnShoot;

    [SerializeField] private GunConfig _config;
    [SerializeField] private GunShakeAnimation _gunShakeAnimation;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPos;
    [SerializeField] private BulletCasing _bulletCasing;
    [SerializeField] private Transform _bulletCasingSpawnPos;

    protected bool _canShot = true;
    protected bool _isEnoughAmmo;
    protected bool _isReloading;
    protected bool _isNPC;

    protected int _ammoCount;
    protected int _magazineCapacity;
    protected int _ammoCountInMagazine;
    protected float _timeBetweenShots;
    protected float _reloadTime;
    protected float _bulletsSpreads;
    protected float _bulletSpeed;
    protected float _cameraShake;

    public void Initialize(bool isNPC)
    {
        _isNPC = isNPC;

        _ammoCount = _config.AmmoCount;
        _magazineCapacity = _config.MagazineCapacity;
        _timeBetweenShots = _config.TimeBetweenShots;
        _reloadTime = _config.ReloadTime;
        _bulletsSpreads = _config.BulletsSpreads;
        _bulletSpeed = _config.BulletSpeed;
        _cameraShake = _config.CameraShake;

        _ammoCount -= 5;

        if (_ammoCount > 0)
        {
            _isEnoughAmmo = true;

            if (_ammoCount < _magazineCapacity)
                _ammoCountInMagazine = _ammoCount;
            else
                _ammoCountInMagazine = _magazineCapacity;
        }

        ShowAmmoEvent();

        _gunShakeAnimation.Initialize(this, _timeBetweenShots);
    }

    public void ShowAmmoEvent()
    {
        AmmoChange?.Invoke(_ammoCountInMagazine, _ammoCount);
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
        if (_canShot && _isEnoughAmmo)
        {
            _canShot = false;
            OneShot();
            SpawnBulletCasing();

            ReduceAmmo();

            await UniTask.Delay(TimeSpan.FromSeconds(_timeBetweenShots));
            _canShot = true;
        }
    }

    protected void OneShot()
    {
        GameObject bullet = _bulletPrefab.Spawn(_bulletSpawnPos, transform.rotation);

        if (bullet.TryGetComponent(out Bullet component))
        {
            Vector3 direction = transform.up + new Vector3(0, GetRandomSpread(), 0);

            Rigidbody2D bulletRb = component.GetRigidbody();
            bulletRb.AddForce(direction * _config.BulletSpeed, ForceMode2D.Impulse);

            CameraShake.Instance.ShakeCamera(_cameraShake);
            OnShoot?.Invoke();
        }
    }

    protected void ReduceAmmo()
    {
        _ammoCountInMagazine--;
        AmmoChange?.Invoke(_ammoCountInMagazine, _ammoCount);

        if (_ammoCountInMagazine <= 0)
        {
            _isEnoughAmmo = false;

            if (_isNPC)
                ReloadMagazine();
        }
    }

    protected void SpawnBulletCasing()
    {
        Vector2 bulletCasingDirection = transform.right;

        BulletCasing casing = Instantiate(_bulletCasing, _bulletCasingSpawnPos.position, Quaternion.identity);
        casing.Spawn(bulletCasingDirection);
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

    private float GetRandomSpread()
    {
        float value = UnityEngine.Random.Range(-_bulletsSpreads, _bulletsSpreads);

        return value;
    }
}
