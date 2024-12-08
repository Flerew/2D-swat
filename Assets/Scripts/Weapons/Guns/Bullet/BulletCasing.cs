using System.Collections;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletCasing : MonoBehaviour
{
    private const float Rotation = 360; 
    private const float MinX = 0.2f; 
    private const float MinY = 0.1f; 

    [SerializeField] private float _maxRandomX = 0.5f;
    [SerializeField] private float _maxRandomY = 0.2f;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private float _lifeTime = 10f;
    [SerializeField, Range(0, 1)] private float _force—oefficient = 0.1f;

    private Rigidbody2D _rb;

    public void Spawn(Vector2 direction)
    {
        _rb = GetComponent<Rigidbody2D>();

        StartCoroutine(DestroyAfterTime());

        float randomXDeviation = Random.Range(MinX, _maxRandomX);
        float randomYDeviation = Random.Range(MinY, _maxRandomY);

        direction = new Vector2(direction.x + randomXDeviation, direction.y + randomYDeviation) * _force—oefficient;
        _rb.AddForce(direction, ForceMode2D.Impulse);

        float randomRotateDeviation = Random.Range(0, Rotation);

        transform.DORotate(new Vector3(0, 0, Rotation + randomRotateDeviation), _duration, RotateMode.FastBeyond360);
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
