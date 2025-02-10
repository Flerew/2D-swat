using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FinalPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panelObjects;
    [SerializeField] private List<GameObject> _hideObjects;

    private CursorController _cursorController;

    [Inject]
    private void Construct(CursorController cursorController)
    {
        _cursorController = cursorController;
    }

    public void ShowPanel()
    {
        HideObjects();
        _cursorController.SetDefaultCursor();

        foreach (GameObject obj in _panelObjects)
        {
            obj.SetActive(true);
        }
    }

    private void HideObjects()
    {
        foreach (GameObject obj in _hideObjects)
        {
            obj.SetActive(false);
        }
    }
}
