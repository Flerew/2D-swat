using System;

public interface IShoot
{
    public event Action<float> Shoot;
    public event Action<float> Reload;

    void GetShooting();
}
