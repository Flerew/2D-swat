using System;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class MoveStateConfig
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _minStayTime;
        [SerializeField] private float _maxStayTime;
        [SerializeField, Range(0, 100)] private int _stayChance;
        [SerializeField, Range(0f, 10f)] private float _rotateSpeed;

        public float Speed => _speed;
        public float MinStayTime => _minStayTime;
        public float MaxStayTime => _maxStayTime;
        public int StayChance => _stayChance;
        public float RotateSpeed => _rotateSpeed;
    }
}