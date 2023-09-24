using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateMachine : StateMachine
{
    public override void OnExcute(CharacterController tInput)
    {
        tInput.ExcuteIdle();
    }

    public override void OnExit(CharacterController tInput)
    {
        tInput.ExitIdle();
    }

    public override void OnStart(CharacterController tInput)
    {
        tInput.StartIdle();
    }
}
