using UnityEngine;
using Random = UnityEngine.Random;

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
            }
        }

        protected void LookAtTarget(Transform target, float time)
        {
            Vector3 direction = target.position - _enemy.transform.position;
            float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            Quaternion targetRotation = Quaternion.Euler(0, 0, rotateZ);
            _enemy.transform.rotation = Quaternion.Lerp(_enemy.transform.rotation, targetRotation, time * Time.deltaTime);
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
