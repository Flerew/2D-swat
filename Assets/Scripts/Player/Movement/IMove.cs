using System;
using UnityEngine;

public interface IMove
{
    public event Action<Vector2> Move;
    public event Action<float> SlowMove;

    void GetMove();
}
