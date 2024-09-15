using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletHole _bulletHole;
    [SerializeField] private List<BulletTrigger> _bulletTriggers;

    private void Awake()
    {
        foreach (BulletTrigger trigger in _bulletTriggers)
        {
            trigger.OnCollisionDetected += SpawnHole;
        }
    }

    public GameObject Spawn(Transform spawnPos, Quaternion rotation)
    {
        return Instantiate(gameObject, spawnPos.position, rotation);
    }

    public Rigidbody2D GetRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }

    private void SpawnHole(RaycastHit2D hit)
    {
        // Need to check layer
        _bulletHole.SpawnHole(hit, transform);
        Destroy(gameObject);
    }
}
