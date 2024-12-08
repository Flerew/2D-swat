namespace Enemy
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : IState;
    }
}
