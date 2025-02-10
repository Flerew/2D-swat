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

            _enemy.LookAtTarget(_viewTrigger.LastPlayerPositionPoint.transform, _config.RotateSpeed, _config.AdditionalDegree);
        }
    }
}
