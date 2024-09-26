using System;

public interface IShoot
{
    event Action<float> Shoot;
    event Action<float> Reload;

    void GetShooting();
}
