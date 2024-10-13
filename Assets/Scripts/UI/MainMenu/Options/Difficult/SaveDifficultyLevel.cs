using UnityEngine;

public class SaveDifficultyLevel
{
    private const string DifficultLevelString = "DifficultLevel";

    public void SaveLevelValue(int value)
    {
        PlayerPrefs.SetInt(DifficultLevelString, value);
    }

    public int GetLevelValue()
    {
        if (PlayerPrefs.HasKey(DifficultLevelString) == false)
            SetDefault();

        int value = PlayerPrefs.GetInt(DifficultLevelString);

        return value;
    }

    private void SetDefault()
    {
        int defaultValue = 0;

        SaveLevelValue(defaultValue);
    }
}
