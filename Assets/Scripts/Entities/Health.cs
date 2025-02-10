using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Health
{
    public event Action Death;

    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health -= damage;

        if(_health <= 0)
            Death?.Invoke();
    }
}
