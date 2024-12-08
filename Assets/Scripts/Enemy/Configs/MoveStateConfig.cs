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

        public float Speed => _speed;
        public float MinStayTime => _minStayTime;
        public float MaxStayTime => _maxStayTime;
        public int StayChance => _stayChance;
    }
}