using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController
{
    private Texture2D _cursorTexture;

    public CursorController(Texture2D cursorTexture)
    {
        _cursorTexture = cursorTexture;
    }

    public void SetDefaultCursor() => SetCursor(null);

    public void SetGameplayCursor() => SetCursor(_cursorTexture);

    private void SetCursor(Texture2D texture)
    {
        Vector2 hotSpot = new Vector2(0, 0);
        CursorMode cursorMode = CursorMode.Auto;

        Cursor.SetCursor(texture, hotSpot, cursorMode);
    }
}
