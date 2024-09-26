using System;
using UnityEngine;

public interface IMove
{
    event Action<Vector2> Move;
    event Action<float> SlowMove;

    void GetMove();
}
