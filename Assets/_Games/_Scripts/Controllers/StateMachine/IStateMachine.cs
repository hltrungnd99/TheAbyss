public interface IStateMachine
{
    public void OnStart(CharacterController cha);
    public void OnExcute(CharacterController cha);
    public void OnExit(CharacterController cha);
}