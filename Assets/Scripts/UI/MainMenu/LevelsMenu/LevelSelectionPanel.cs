using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private SelectLevelButton[] _selectLevelButtons;
    [SerializeField] private Gun _selectedGun;

    private SceneLoadMediator _sceneLoader;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void OnEnable()
    {
        foreach (var button in _selectLevelButtons)
            button.Click += OnLevelSelected;
    }

    private void OnDisable()
    {
        foreach (var button in _selectLevelButtons)
            button.Click -= OnLevelSelected;
    }

    private void OnLevelSelected(int level)
    {
        _sceneLoader.GoToGameplayLevel(new LevelLoadingData(DifficultyLevel.Easy), new PlayerLoadingData(_selectedGun), level);
    }
}
