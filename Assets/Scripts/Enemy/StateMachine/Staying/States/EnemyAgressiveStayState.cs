using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAgressiveStayState : EnemyStayState
    {
        private ShootStateConfig _shootConfig;

        public EnemyAgressiveStayState(IStateSwitcher stateSwitcher, EnemyNPC enemy) : base(stateSwitcher, enemy)
        {
            _shootConfig = _enemy.Config.ShootStateConfig;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            _enemy.LookAtTarget(_enemy.ViewTrigger.LastPlayerPositionPoint.transform, _shootConfig.RotateSpeed, _shootConfig.AdditionalDegree);
        }
    }
}
