using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyPassiveStayState : EnemyStayState
    {
        public EnemyPassiveStayState(IStateSwitcher stateSwitcher, EnemyNPC enemy) : base(stateSwitcher, enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _enemy.ViewTrigger.DetectPlayer += SetState;
        }

        public override void Exit()
        {
            _enemy.ViewTrigger.DetectPlayer -= SetState;
        }

        private void SetState()
        {
            if (_enemy.IsAgressive)
                _stateSwitcher.SwitchState<EnemyMoveShootState>();
            else
                _stateSwitcher.SwitchState<EnemyMoveState>();
        }
    }
}
