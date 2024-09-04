using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackToMenuButton : MonoBehaviour
{
    private SceneLoadMediator _loader;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoadMediator)
    {
        _loader = sceneLoadMediator;
    }

    public void OnClick()
    {
        _loader.GoToMainMenu();
    }
}
