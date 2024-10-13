using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultLevelController : MonoBehaviour
{
    [SerializeField] DifficultyLevelDropdown _dropdown;

    private SaveDifficultyLevel _saveDifficult = new SaveDifficultyLevel();

    public SaveDifficultyLevel SaveDifficultyLevel => _saveDifficult;

    private void Awake()
    {
        int dropdawnValue = _saveDifficult.GetLevelValue();

        _dropdown.Initialize(dropdawnValue);
        _dropdown.DifficultyLevelChange += ChangeDifficult;
    }

    private void ChangeDifficult(DifficultyLevel level)
    {
        _saveDifficult.SaveLevelValue((int)level);
    }
}
