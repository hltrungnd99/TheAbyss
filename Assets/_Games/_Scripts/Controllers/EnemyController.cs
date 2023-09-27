
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : CharacterController
{
    [SerializeField] protected NavMeshAgent navMeshEnemy;
    private StateMachine currentStateMachine;



    protected override void SetupStart()
    {
        base.SetupStart();
        ChangeState(new IdleStateMachine());
    }
    protected override void SetupUpdate()
    {
        base.SetupUpdate();
        if (currentStateMachine != null)
        {
            currentStateMachine.OnExcute(this);
        }
    }

    public override void Idle()
    {
        base.Idle();
    }
    public override void Move()
    {
        base.Move();
        float x = Random.Range(-3, 4);
        float z = Random.Range(-3, 4);
        navMeshEnemy.SetDestination(new Vector3(x, 0, z));
    }
    public override void Attack()
    {

    }
    protected void ChangeState(StateMachine stateMachine)
    {
        if (currentStateMachine != stateMachine)
        {
            if (currentStateMachine != null) currentStateMachine.OnExit(this);
            currentStateMachine = stateMachine;
            if (currentStateMachine != null) currentStateMachine.OnStart(this);
        }
    }
}
