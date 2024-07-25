public class LevelLoadingData
{
    private DifficultyLevel _difficultyLevel;

    public LevelLoadingData(DifficultyLevel difficultyLevel)
    {
        _difficultyLevel = difficultyLevel;
    }

    public DifficultyLevel DifficultyLevel => _difficultyLevel;
}
