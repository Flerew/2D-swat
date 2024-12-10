using Cysharp.Threading.Tasks;
using System;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyMoveState : EnemyMovementState
    {
        private const int MaxChance = 100;

        public EnemyMoveState(IStateSwitcher stateSwitcher, EnemyNPC enemy) : base(stateSwitcher, enemy)
        {
        }

        public override void Update()
        {
            MoveToWayPoint();
            if(_currentWayPoint != null) 
                LookAtTarget(_currentWayPoint, _enemyConfig.RotateSpeed);

            if (GetIfPointMaxDistance())
                SetOrStayAtPoint();
        }

        private void SetOrStayAtPoint()
        {
            if (GetStayChance())
                _ = WaitAtOwnPosition();
            else
                SetRandomWayPoint();
        }

        private async UniTaskVoid WaitAtOwnPosition()
        {
            _currentWayPoint = null;
            float waitTime = Random.Range(_enemyConfig.MinStayTime, _enemyConfig.MaxStayTime);

            await UniTask.Delay(TimeSpan.FromSeconds(waitTime));

            SetRandomWayPoint();
        }

        private bool GetStayChance()
        {
            float chance = Random.Range(0, 100);

            if (chance < _enemyConfig.StayChance)
                return true;
            else 
                return false;
        }
    }
}