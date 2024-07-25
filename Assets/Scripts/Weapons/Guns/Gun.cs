using System.Collections;
using UnityEngine;

public abstract class Gun : Weapon
{
    [SerializeField] private GunConfig _config;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPos;
    [SerializeField] private GameObject _bulletCasing;

    private bool _canShot = true;
    private bool _isEnoughAmmo;

    public float Damage { get; private set; }
    public int AmmoCount { get; private set; }
    public int AmmoCountInMagazine { get; private set; }
    public float TimeBetweenShots { get; private set; }
    public float ReloadTime { get; private set; }
    public float BulletsSpreads { get; private set; }
    public float BulletSpeed { get; private set; }

    public void Initialize()
    {
        Damage = _config.Damage;
        AmmoCount = _config.AmmoCount;
        AmmoCountInMagazine = _config.AmmoCountInMagazine;
        TimeBetweenShots = _config.TimeBetweenShots;
        ReloadTime = _config.ReloadTime;
        BulletsSpreads = _config.BulletsSpreads;
        BulletSpeed = _config.BulletSpeed;

        if(AmmoCount > 0)
            _isEnoughAmmo = true;
    }

    public virtual void Shoot()
    {
        TryShoot();
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
            }

            ReduceAmmo();
            StartCoroutine(WaitBetweenShots());

            return true;
        }
        else
        {
            return false;
        }
    }

    protected void ReduceAmmo()
    {
        AmmoCountInMagazine--;

        if (AmmoCountInMagazine <= 0)
            _isEnoughAmmo = false;
    }

    //private bool TryReloadMagazine()
    //{
    //    //if(AmmoCount > 0) 

    //}

    private IEnumerator WaitBetweenShots()
    {
        _canShot = false;
        yield return new WaitForSeconds(TimeBetweenShots);
        _canShot = true;
    }
}
