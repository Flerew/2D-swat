using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;

    public override void InstallBindings()
    {
        BindControls();    
        BindInstance();
    }

    private void BindInstance()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_player, _playerSpawnPosition.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
    }

    private void BindControls()
    {
        Container.BindInstance(new PlayerControls(_playerInput)).AsSingle();
    }
}
