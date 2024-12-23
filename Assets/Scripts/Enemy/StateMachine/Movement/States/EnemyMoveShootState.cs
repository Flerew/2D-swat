using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMoveShootState : EnemyMovementState
    {
        private ViewTrigger _viewTrigger;
        private ShootStateConfig _config;

        public EnemyMoveShootState(IStateSwitcher stateSwitcher, EnemyNPC enemy) : base(stateSwitcher, enemy)
        {
            _viewTrigger = enemy.ViewTrigger;
            _config = enemy.Config.ShootStateConfig;
        }

        public override void Update()
        {
            base.Update();

            LookAtTarget(_viewTrigger.LastPlayerPositionPoint.transform, _config.RotateSpeed);
        }
    }
}
