using System.Collections.Generic;
using System.Linq;

namespace Enemy
{
    public class EnemyStateMachine : IStateSwitcher
    {
        protected List<IState> _states;
        protected IState _currentState;

        public EnemyStateMachine(EnemyNPC enemy)
        {
            _states = new List<IState>()
            {
                new EnemyMoveState(this, enemy),
                new EnemyMoveShootState(this, enemy)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(s => s is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState.Update();
        }
    }
}
