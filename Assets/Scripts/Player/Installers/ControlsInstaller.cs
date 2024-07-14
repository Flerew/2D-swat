using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsInstaller : MonoInstaller
{
    [SerializeField] private PlayerInput _playerInput;

    public override void InstallBindings()
    {
        Container.BindInstance(new PlayerControls(_playerInput)).AsSingle();
    }
}
