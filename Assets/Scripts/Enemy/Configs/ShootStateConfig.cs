using System;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class ShootStateConfig
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _additionalDegree = 5f;

        public float RotateSpeed => _rotateSpeed;
        public float AdditionalDegree => _additionalDegree;

    }
}