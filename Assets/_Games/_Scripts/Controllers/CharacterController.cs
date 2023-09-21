using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody myRig;
    [SerializeField] protected StatsCharacterBase statsCharacterBase;
    [SerializeField] protected Animator animatorCharacter;

    protected Vector3 directionMove = Vector3.zero;
    protected bool isCanMove;

    private string currentStateAnim;

    public StatCharacter statCharacter;

    private StateMachine currentStateMachine;

    private void Start()
    {
        statCharacter.Clone(statsCharacterBase.statCharacter);

        SetupStart();
    }

    private void Update()
    {
        if (currentStateMachine != null)
        {
            currentStateMachine.OnExcute();
        }
        SetupUpdate();
    }

    protected virtual void SetupStart()
    {

    }

    protected virtual void SetupUpdate()
    {

    }

    //private void Move()
    //{
    //    if (directionMove.magnitude < 0.05f)
    //    {
    //        if (currentStateAnim != "idle")
    //        {
    //            currentStateAnim = "idle";
    //            animatorCharacter.SetTrigger("idle");
    //        }
    //        myRig.velocity = Vector3.zero;
    //    }
    //    else
    //    {
    //        myRig.velocity = directionMove * statCharacter.statCharacterOther.MSPD;

    //        if (directionMove.magnitude < 0.6f)
    //        {
    //            if (currentStateAnim != "walk")
    //            {
    //                currentStateAnim = "walk";
    //                animatorCharacter.SetTrigger("walk");
    //            }
    //        }
    //        else
    //        {
    //            if (currentStateAnim != "run")
    //            {
    //                currentStateAnim = "run";
    //                animatorCharacter.SetTrigger("run");
    //            }
    //        }
    //    }

    //}

    //private void Rotate()
    //{
    //    if (directionMove.magnitude >= 0.05f)
    //    {
    //        var angle = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * 10);
    //    }
    //}

    //private void Attack()
    //{
    //    animatorCharacter.SetTrigger("attack");
    //}

    protected void ChangeState(StateMachine stateMachine)
    {
        if (currentStateMachine != stateMachine)
        {
            if (currentStateMachine != null) currentStateMachine.OnExit();
            currentStateMachine = stateMachine;
            if (currentStateMachine != null) currentStateMachine.OnStart();
        }
    }
}
