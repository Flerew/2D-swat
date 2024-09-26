using System;
using UnityEngine;

public interface ILook 
{
    event Action<Vector2> Look;

    void GetMobileLook();
}
