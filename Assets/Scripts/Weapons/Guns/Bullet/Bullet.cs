using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public GameObject Spawn(Transform spawnPos, Quaternion rotation)
    {
        return Instantiate(gameObject, spawnPos.position, rotation);
    }

    public Rigidbody2D GetRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }
}
