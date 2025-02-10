using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _deathIndicator;

    protected Collider2D _collider;
    protected Rigidbody2D _rb;

    public Health Health => _health;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();

        Initialize();

        Health.Death += Death;
    }

    private void OnDestroy()
    {
        Health.Death -= Death;
    }

    protected virtual void Initialize() { }

    private void Death()
    {
        _deathIndicator.SetActive(true);
        _collider.enabled = false;
        this.enabled = false;
    }
}
