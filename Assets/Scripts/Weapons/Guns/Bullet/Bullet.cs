using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletHole _bulletHole;
    [SerializeField] private List<BulletTrigger> _bulletTriggers;
    [SerializeField] private float _lifeTime = 20f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _killSpeed = 5f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        foreach (BulletTrigger trigger in _bulletTriggers)
        {
            trigger.OnCollisionDetected += SpawnHole;
        }

        StartCoroutine(DestroyAfterTime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Entity entity))
        {
            if(_rb.velocity.magnitude > _killSpeed)
                entity.Health.TakeDamage(_damage); // Should Check bullet speed
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

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
