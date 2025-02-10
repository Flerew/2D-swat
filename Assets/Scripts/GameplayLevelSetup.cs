using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayLevelSetup : MonoBehaviour
{
    private CursorController _cursorController;

    [Inject]
    private void Construct(CursorController cursorController)
    {
        Application.targetFrameRate = 60;

        _cursorController = cursorController;
    }

    private void Start()
    {
        _cursorController.SetGameplayCursor();
    }

    private void OnDestroy()
    {
        _cursorController.SetDefaultCursor();
    }
}
