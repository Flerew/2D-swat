using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHole : MonoBehaviour
{
    public void SpawnHole(RaycastHit2D hit, Transform bulletPos)
    {
        Instantiate(gameObject, hit.point, Quaternion.identity);
    }
}
