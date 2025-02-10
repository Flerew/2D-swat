using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DeathPanel : FinalPanel
{
    [SerializeField] private Button _restartButton;

    private SceneLoadMediator _sceneLoader;

    [Inject]
    private void Construct(Player player, SceneLoadMediator sceneLoader)
    {
        _sceneLoader = sceneLoader;

        _restartButton.onClick.AddListener(RestartLevel);
    }

    public void PlayerDeath()
    {
        base.ShowPanel();
    }

    private void RestartLevel()
    {
        _sceneLoader.RestartCurrentLevel();
    }
}
