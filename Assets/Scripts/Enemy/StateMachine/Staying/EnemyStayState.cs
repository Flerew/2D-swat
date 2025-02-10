using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public abstract class EnemyStayState : IState
    {
        protected IStateSwitcher _stateSwitcher;
        protected EnemyNPC _enemy;
        protected StayConfig _config;

        public EnemyStayState(IStateSwitcher stateSwitcher, EnemyNPC enemy)
        {
            _stateSwitcher = stateSwitcher;
            _enemy = enemy;
            _config = enemy.Config.StayConfig;
        }

        public virtual void Enter()
        {
            _ = StayAtPosition();
        }

        public virtual void Exit()
        {
            _stateSwitcher.SwitchState<EnemyMoveState>();
        }

        public virtual void Update()
        {
        }

        private async UniTaskVoid StayAtPosition()
        {
            float waitTime = Random.Range(_config.MinStayTime, _config.MaxStayTime);

            await UniTask.Delay(TimeSpan.FromSeconds(waitTime));

            Exit();
        }
    }
}