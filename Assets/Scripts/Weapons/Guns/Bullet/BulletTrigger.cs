using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private const float MinTargetDistance = 0.1f;

    public event Action<RaycastHit2D> OnCollisionDetected;

    private void FixedUpdate()
    {
        CheckRaycast();
    }

    private void CheckRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, LayerMask.GetMask("Walls"));

        if (hit.collider != null && CheckAllowDistance(hit))
        {
            OnCollisionDetected?.Invoke(hit);
        }
    }

    private bool CheckAllowDistance(RaycastHit2D hit)
    {
        float distance = Vector3.Distance(transform.position, hit.point);
        Debug.Log(distance);

        if (distance < MinTargetDistance)
        {
            return true;
        }
        else
            return false;
    }
}
