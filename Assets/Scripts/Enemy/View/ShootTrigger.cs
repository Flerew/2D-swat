using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    private const string TargetTag = "EnemyTarget";

    [SerializeField] private float _shootDistance = 12f;


    public event Action DetectTarget;

    private void Update()
    {
        CreateRays();
    }

    private void CreateRays()
    {
        int layerMaskOnlyTrigger = 1 << LayerMask.NameToLayer("ObjectTrigger");
        int layerMaskWithoutTrigger = ~layerMaskOnlyTrigger;

        Vector2 direction = transform.up * 100;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _shootDistance, layerMaskWithoutTrigger);

        if (hit.collider != null && hit.collider.gameObject.tag == TargetTag)
        {
            DetectTarget?.Invoke();
        }
    }
}
