using Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    public event Action EndLevel;

    [SerializeField] private List<Entity> _targetEnemies;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private DeathPanel _deathPanel;

    private int _enemiesCount;
    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;

        _enemiesCount = _targetEnemies.Count;

        foreach (Entity ent in _targetEnemies)
        {
            ent.Health.Death += OnEnemyDeath;
        }

        _player.Health.Death += OnPlayerDeath;
    }


    private void OnEnemyDeath()
    {
        _enemiesCount--;

        if (_enemiesCount <= 0)
        {
            EndLevel?.Invoke();
            _winPanel.EnemiesDeath();
            _player.SwitchControls(false);
        }
    }

    private void OnPlayerDeath()
    {
        _deathPanel.PlayerDeath();
    }
}
