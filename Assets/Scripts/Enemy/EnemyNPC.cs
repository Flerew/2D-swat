using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyNPC : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private List<Transform> _wayPoints;
        [SerializeField] private Gun _gun;

        private EnemyStateMachine _stateMachine;

        public EnemyConfig Config => _config;
        public List<Transform> WayPoints => _wayPoints;

        private void Awake()
        {
            _gun.Initialize();

            _stateMachine = new EnemyStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void Shoot()
        {
            _gun.Shoot();
        }
    }
}