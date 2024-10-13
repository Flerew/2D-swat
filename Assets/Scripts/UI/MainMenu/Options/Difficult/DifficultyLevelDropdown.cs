using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyLevelDropdown : MonoBehaviour
{
    public event Action<DifficultyLevel> DifficultyLevelChange;

    private Dropdown _dropdown;

    public void Initialize(int value)
    {
        _dropdown = GetComponent<Dropdown>();

        _dropdown.value = value;
    }

    public void OnMenuChoice()
    {
        int value = _dropdown.value;

        DifficultyLevelChange?.Invoke((DifficultyLevel)value);
    }
}
