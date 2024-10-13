using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTarget : MonoBehaviour
{
    public event Action OnBulletHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            OnBulletHit?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
