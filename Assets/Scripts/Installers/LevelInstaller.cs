using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Texture2D _cursorTexture;

    public override void InstallBindings()
    {
        Container.BindInstance(new CursorController(_cursorTexture)).AsSingle();
    }
}
