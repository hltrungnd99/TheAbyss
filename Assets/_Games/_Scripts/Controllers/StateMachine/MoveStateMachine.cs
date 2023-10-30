public class MoveStateMachine : IStateMachine
{
    public void OnStart(CharacterController cha)
    {
        cha.ChangeAnim(ConstAnimParams.PLAYER_ANIM_RUN);
        cha.eCharacterState = ECharacterState.MOVE;
        cha.StartMove();
    }

    public void OnExcute(CharacterController cha)
    {
        cha.ExcuteMove();
    }

    public void OnExit(CharacterController cha)
    {
    }
}