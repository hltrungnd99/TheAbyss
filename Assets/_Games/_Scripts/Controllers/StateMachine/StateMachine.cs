public abstract class StateMachine
{
    public abstract void OnStart(EnemyController cha);
    public abstract void OnExcute(EnemyController cha);
    public abstract void OnExit(EnemyController cha);
}
