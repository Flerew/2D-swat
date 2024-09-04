using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private List<GameObject> _menuObjects;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(Pause);
        _resumeButton.onClick.AddListener(Resume);
    }

    private void Pause()
    {
        Time.timeScale = 0f;

        foreach (GameObject obj in _menuObjects)
        {
            obj.SetActive(true);
        }
    }

    private void Resume()
    {
        Time.timeScale = 1f;

        foreach (GameObject obj in _menuObjects)
        {
            obj.SetActive(false);
        }
    }
}
