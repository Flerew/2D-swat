using System;

public interface IInteract
{
    event Action<float> OnInteract;

    void GetInteract();
}
