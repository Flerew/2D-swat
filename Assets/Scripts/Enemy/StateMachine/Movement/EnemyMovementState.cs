using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovementState : IState
    {
        private const float MaxDistance = 0.25f;

        protected IStateSwitcher _stateSwitcher;
        protected EnemyNPC _enemy;
        protected Transform _currentWayPoint;
        protected MoveStateConfig _enemyConfig;

        public EnemyMovementState(IStateSwitcher stateSwitcher, EnemyNPC enemy)
        {
            _stateSwitcher = stateSwitcher;
            _enemy = enemy;
            _enemyConfig = _enemy.Config.MoveStateConfig;
        }

        public virtual void Enter() => SetRandomWayPoint();

        public virtual void Exit() => StopAtOwnPosition();

        public virtual void Update()
        {
            MoveToWayPoint();

            if (GetIfPointMaxDistance())
                SetRandomWayPoint();
        }

        protected void SetRandomWayPoint()
        {
            _currentWayPoint = _enemy.WayPoints[Random.Range(0, _enemy.WayPoints.Count)];
        }

        protected void StopAtOwnPosition()
        {
            _currentWayPoint = _enemy.transform;
        }

        protected void MoveToWayPoint()
        {
            Vector3 enemyPos = _enemy.transform.position;
            float speed = _enemyConfig.Speed;

            if (_currentWayPoint != null)
            {
                _enemy.transform.position = Vector2.MoveTowards(enemyPos, _currentWayPoint.position, speed * Time.deltaTime);

                //LookAtTarget();
                _enemy.LookAtTarget(_currentWayPoint, 2);
            }
        }

        private void LookAtTarget()
        {
            Vector3 direction = _currentWayPoint.position - _enemy.transform.position;
            float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _enemy.transform.rotation = Quaternion.Euler(0, 0, rotateZ);
            //float match = Vector2.Angle(enemyPos, _currentWayPoint.position);
            //_enemy.transform.rotation = new Quaternion(0, 0, match, 0);

            //Vector3 direction = _mousePosition - transform.position;
            //float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            //transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        }

        protected bool GetIfPointMaxDistance()
        {
            if (_currentWayPoint != null)
            {
                float distance = Vector2.Distance(_currentWayPoint.transform.position, _enemy.transform.position);

                if (distance < MaxDistance)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
