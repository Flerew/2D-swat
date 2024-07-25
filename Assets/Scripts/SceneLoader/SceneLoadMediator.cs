public class SceneLoadMediator
{
    private const int MainMenuID = 0;

    private ILevelLoader _levelLoader;
    private ISimpleSceneLoader _simpleSceneLoader;

    public SceneLoadMediator(ILevelLoader sceneLoader, ISimpleSceneLoader simpleSceneLoader)
    {
        _levelLoader = sceneLoader;
        _simpleSceneLoader = simpleSceneLoader;
    }

    public void GoToGameplayLevel(LevelLoadingData levelLoadingData, PlayerLoadingData playerLoadingData, int SceneID)
    {
        _levelLoader.Load(levelLoadingData, playerLoadingData, SceneID);
    }

    public void GoToMainMenu()
    {
        _simpleSceneLoader.Load(MainMenuID);
    }
}
