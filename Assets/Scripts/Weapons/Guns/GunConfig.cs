using UnityEngine;

[CreateAssetMenu(fileName = "PistolGunConfig", menuName = "Config/PistolGunConfig")]
public class GunConfig : ScriptableObject
{
    [SerializeField] private float _damage;
    [SerializeField] private int _ammoCount;
    [SerializeField] private int _ammoCountInMagazine;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _bulletsSpreads;
    [SerializeField] private float _bulletSpeed;

    public float Damage => _damage;
    public int AmmoCount => _ammoCount;
    public int AmmoCountInMagazine => _ammoCountInMagazine;
    public float TimeBetweenShots => _timeBetweenShots;
    public float ReloadTime => _reloadTime;
    public float BulletsSpreads => _bulletsSpreads;
    public float BulletSpeed => _bulletSpeed;
}
