using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class StayConfig
    {
        [SerializeField] private float _minStayTime;
        [SerializeField] private float _maxStayTime;
        
        public float MinStayTime => _minStayTime;
        public float MaxStayTime => _maxStayTime;
    }
}