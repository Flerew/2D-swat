using UnityEngine;

public class SceneLoader : ILevelLoader, ISimpleSceneLoader
{
    private ZenjectSceneLoaderWrapper _sceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Load(LevelLoadingData levelLoadingData, PlayerLoadingData playerLoadingData, int SceneId)
    {
        _sceneLoader.Load(SceneId,
            container =>
            {
                container.BindInstance(levelLoadingData);
                container.BindInstance(playerLoadingData);
            });
    }

    public void Load(int sceneId)
    {
        _sceneLoader.Load(sceneId);
    }
}
