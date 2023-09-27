using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateMachine : StateMachine
{
    public override void OnExcute(EnemyController cha)
    {
    }

    public override void OnExit(EnemyController cha)
    {
        tInput.ExcuteIdle();
    }

    public override void OnStart(EnemyController cha)
    {
    }
}
