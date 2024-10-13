using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private SelectLevelButton[] _selectLevelButtons;
    [SerializeField] private Equipment _equipment;
    [SerializeField] private DifficultLevelController _difficultLevelController;

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
        int difficultLevel = _difficultLevelController.SaveDifficultyLevel.GetLevelValue();

        LevelLoadingData levelLoadingData = new LevelLoadingData((DifficultyLevel)difficultLevel);
        PlayerLoadingData playerLoadingData = new PlayerLoadingData(_equipment.Gun);

        _sceneLoader.GoToGameplayLevel(levelLoadingData, playerLoadingData, level);
    }

}
