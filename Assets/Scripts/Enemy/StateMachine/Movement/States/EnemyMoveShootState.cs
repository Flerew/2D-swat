using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveShootState : EnemyMovementState
{
    public EnemyMoveShootState(IStateSwitcher stateSwitcher, EnemyNPC enemy) : base(stateSwitcher, enemy)
    {
    }

    public override void Update()
    {
        base.Update();

        //LookAtTarget()
    }
}
