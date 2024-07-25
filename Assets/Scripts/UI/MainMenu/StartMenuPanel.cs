using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuPanel : MonoBehaviour
{
    [Header("Play Button")]
    [SerializeField] private Button _playButton;
    [SerializeField] private List<GameObject> _showObjects;
    [SerializeField] private List<GameObject> _hideObjects;

    [Header("Exit Button")]
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(ClickOnPlayButton);
        _exitButton.onClick.AddListener(ClickOnExitButton);
    }

    private void ClickOnPlayButton()
    {
        foreach (GameObject obj in _hideObjects) 
        { 
            obj.SetActive(false);
        }

        foreach(GameObject obj in _showObjects) 
        { 
            obj.SetActive(true);
        }
    }

    private void ClickOnExitButton()
    {
        Application.Quit();
    }
}
