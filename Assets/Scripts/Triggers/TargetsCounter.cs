using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsCounter : MonoBehaviour
{
    [SerializeField] private List<TrainingTarget> _targets;
    [SerializeField] private Door _door;
    [SerializeField] private int _hitCountToOpen;

    private void Awake()
    {
        foreach (TrainingTarget target in _targets)
        {
            target.OnBulletHit += TargetHit;
        }
    }

    private void TargetHit()
    {
        _hitCountToOpen--;

        if (_hitCountToOpen <= 0)
            _door.LockDoor(false);
    }
}
