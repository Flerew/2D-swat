using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyNPC : Entity
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private List<Transform> _wayPoints;
        [SerializeField] private Gun _gun;
        [SerializeField] private ViewTrigger _viewTrigger;
        [SerializeField] private ShootTrigger _shootTrigger;

        private EnemyStateMachine _stateMachine;

        public EnemyConfig Config => _config;
        public List<Transform> WayPoints => _wayPoints;
        public ViewTrigger ViewTrigger => _viewTrigger;
        public bool IsAgressive { get; private set; }

        protected override void Initialize()
        {
            _gun.Initialize(true);

            _stateMachine = new EnemyStateMachine(this);

            _viewTrigger.DetectPlayer += DetectPlayer;
            _shootTrigger.DetectTarget += Shoot;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void Shoot()
        {
            _gun.Shoot();
        }

        public void LookAtTarget(Transform target, float time, float AdditionalDegree = 0f)
        {
            Vector3 direction = target.position - transform.position;
            float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            Quaternion targetRotation = Quaternion.Euler(0, 0, rotateZ + AdditionalDegree);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, time * Time.deltaTime);
        }

        private void DetectPlayer()
        {
            IsAgressive = true;
        }
    }
}