using System;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader
{
    private readonly ZenjectSceneLoader _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoader zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void Load(Action<DiContainer> action, int sceneId)
    {
        _zenjectSceneLoader.LoadScene(sceneId, LoadSceneMode.Single, container => action?.Invoke(container));
    }
}
