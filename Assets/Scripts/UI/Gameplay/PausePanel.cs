using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PausePanel : MonoBehaviour
{
    public event Action<bool> Pause;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private List<GameObject> _menuObjects;

    private CursorController _cursorController;

    [Inject]
    private void Construct(CursorController cursorController)
    {
        _cursorController = cursorController;

        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _backToMenuButton.onClick.AddListener(ResumeGame);
    }

    private void PauseGame()
    {
        _cursorController.SetDefaultCursor();

        Time.timeScale = 0f;
        Pause?.Invoke(true);

        foreach (GameObject obj in _menuObjects)
        {
            obj.SetActive(true);
        }
    }

    private void ResumeGame()
    {
        _cursorController.SetGameplayCursor();

        Time.timeScale = 1f;
        Pause?.Invoke(false);

        foreach (GameObject obj in _menuObjects)
        {
            obj.SetActive(false);
        }
    }
}
