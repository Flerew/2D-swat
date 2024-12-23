using System;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class ShootStateConfig
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _shootDegree;

        public float RotateSpeed => _rotateSpeed;
        public float ShootDegree => _shootDegree;
    }
}