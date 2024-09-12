using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public event Action<bool> Pause;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private List<GameObject> _menuObjects;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _backToMenuButton.onClick.AddListener(ResumeGame);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Pause?.Invoke(true);

        foreach (GameObject obj in _menuObjects)
        {
            obj.SetActive(true);
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        Pause?.Invoke(false);

        foreach (GameObject obj in _menuObjects)
        {
            obj.SetActive(false);
        }
    }
}
