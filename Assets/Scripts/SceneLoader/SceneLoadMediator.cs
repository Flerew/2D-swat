using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoadMediator
{
    private const int MainMenuID = 0;

    private ILevelLoader _levelLoader;
    private ISimpleSceneLoader _simpleSceneLoader;

    private int _sceneId;

    private LevelLoadingData _levelLoadingData;
    private PlayerLoadingData _playerLoadingData;

    [Inject]
    private void Construct(LevelLoadingData levelLoadingData = null, PlayerLoadingData playerLoadingData = null)
    {
        _levelLoadingData = levelLoadingData;
        _playerLoadingData = playerLoadingData;
    }

    public SceneLoadMediator(ILevelLoader sceneLoader, ISimpleSceneLoader simpleSceneLoader)
    {
        _levelLoader = sceneLoader;
        _simpleSceneLoader = simpleSceneLoader;
    }

    public void GoToGameplayLevel(LevelLoadingData levelLoadingData, PlayerLoadingData playerLoadingData, int sceneId)
    {
        _levelLoader.Load(levelLoadingData, playerLoadingData, sceneId);
    }

    public void RestartCurrentLevel()
    {
        _levelLoader.Load(_levelLoadingData, _playerLoadingData, SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        _simpleSceneLoader.Load(MainMenuID);
    }
}
