using System;
using UnityEngine;

public interface ILook 
{
    public event Action<Vector2> Look;

    void GetMobileLook();
}
