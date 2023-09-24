public abstract class StateMachine
{
    public abstract void OnStart(CharacterController tInput);
    public abstract void OnExcute(CharacterController tInput);
    public abstract void OnExit(CharacterController tInput);
}
