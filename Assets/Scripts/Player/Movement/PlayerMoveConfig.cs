using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveConfig", menuName = "Config/PlayerMoveConfig")]
public class PlayerMoveConfig : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _slowMoveSpeed = 1f;
    [SerializeField] private float _deceleration = 0.9f;

    public float MoveSpeed => _moveSpeed;
    public float SlowMoveSpeed => _slowMoveSpeed;
    public float Deceleration => _deceleration;
}
