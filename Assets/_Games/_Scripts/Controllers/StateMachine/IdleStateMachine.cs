using UnityEngine;

public class IdleStateMachine : IStateMachine
{
    private ECharacterState preState;
    private float timeDelayAtk;
    private float maxTimeDelayAtk = 1;

    public void OnStart(CharacterController cha)
    {
        preState = cha.eCharacterState;
        cha.ChangeAnim(ConstAnimParams.PLAYER_ANIM_IDLE);
        cha.eCharacterState = ECharacterState.IDLE;
        timeDelayAtk = 0;
    }

    public void OnExcute(CharacterController cha)
    {
        if (preState == ECharacterState.ATTACK)
        {
            timeDelayAtk += Time.deltaTime;
            if (timeDelayAtk > maxTimeDelayAtk)
            {
                cha.ExcuteIdle();
            }
        }
        else
        {
            cha.ExcuteIdle();
        }
    }

    public void OnExit(CharacterController cha)
    {
    }
}