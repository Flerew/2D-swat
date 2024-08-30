using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseUIButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> _showUI;
    [SerializeField] private List<GameObject> _hideUI;

    public void OnClick()
    {
        Hide();
        Show();
    }

    private void Hide()
    {
        foreach (GameObject obj in _hideUI)
        {
            obj.SetActive(false);
        }
    }

    private void Show()
    {
        foreach (GameObject obj in _showUI)
        {
            obj.SetActive(true);
        }
    }
}
