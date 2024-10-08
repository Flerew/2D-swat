using UnityEngine;

[CreateAssetMenu(fileName = "PistolGunConfig", menuName = "Config/GunConfig")]
public class GunConfig : ScriptableObject
{
    [SerializeField] private float _damage;
    [SerializeField] private int _ammoCount;
    [SerializeField] private int _magazineCapacity;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _bulletsSpreads;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _cameraShake;

    public float Damage => _damage;
    public int AmmoCount => _ammoCount;
    public int MagazineCapacity => _magazineCapacity;
    public float TimeBetweenShots => _timeBetweenShots;
    public float ReloadTime => _reloadTime;
    public float BulletsSpreads => _bulletsSpreads;
    public float BulletSpeed => _bulletSpeed;
    public float CameraShake => _cameraShake;
}
