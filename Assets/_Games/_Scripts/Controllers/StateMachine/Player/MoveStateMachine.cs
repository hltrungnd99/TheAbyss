using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStateMachine : StateMachine
{
    public override void OnExcute(CharacterController tInput)
    {
        tInput.ExcuteMove();
    }

    public override void OnExit(CharacterController tInput)
    {
        tInput.ExitMove();
    }

    public override void OnStart(CharacterController tInput)
    {
        tInput.StartMove();
    }
}
