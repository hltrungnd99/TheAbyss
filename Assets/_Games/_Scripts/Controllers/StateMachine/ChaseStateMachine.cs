public class ChaseStateMachine : IStateMachine
{
    public void OnStart(CharacterController cha)
    {
        cha.eCharacterState = ECharacterState.CHASE;
        cha.ChangeAnim(ConstAnimParams.PLAYER_ANIM_RUN);
        cha.StartChase();
    }

    public void OnExcute(CharacterController cha)
    {
        cha.ExcuteChase();
    }

    public void OnExit(CharacterController cha)
    {
        cha.ExitChase();
    }
}