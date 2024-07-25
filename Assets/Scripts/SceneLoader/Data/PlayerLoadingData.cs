public class PlayerLoadingData
{
    private Gun _playerGun;

    public PlayerLoadingData(Gun playerGun)
    {
        _playerGun = playerGun;
    }

    public Gun PlayerGun => _playerGun;
}
