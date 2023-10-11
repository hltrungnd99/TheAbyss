using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // [SerializeField] protected Rigidbody myRig;
    // [SerializeField] protected StatsCharacterBase statsCharacterBase;
    // [SerializeField] protected Animator animatorCharacter;
    //
    // protected ECharacterState eCharacterState;
    // protected Vector3 directionMove = Vector3.zero;
    // protected bool IsDead => statCharacter.statCharacterDMF.HP <= 0 || eCharacterState == ECharacterState.DIE;
    //
    // public StatCharacter statCharacter;
    //
    // private IStateMachine currentStateMachine;
    // private string currentStateAnim;
    // private float takeMoreDamage;
    // [SerializeField] protected string myStatBase;
    //
    // private string currentStateAnim;
    // protected bool isCanMove;
    //
    // public StatCharacter statCharacter;
    //
    //
    // private void Start()
    // {
    //     // if set up data
    //     statCharacter = new StatCharacter();
    //     statCharacter.Clone(SetupTypeStat());
    //
    //     SetupStart();
    // }
    //
    // private void Update()
    // {
    //     if (currentStateMachine != null)
    //     {
    //         currentStateMachine.OnExcute(this);
    //     }
    //
    //     SetupUpdate();
    // }
    //
    // private void FixedUpdate()
    // {
    //     SetupFixedUpdate();
    // }
    //
    // protected StatCharacter SetupTypeStat()
    // {
    //     for (int i = 0; i < statsCharacterBase.statCharacter.Length; i++)
    //     {
    //         if (myStatBase.Contains(statsCharacterBase.statCharacter[i].characterStat))
    //         {
    //             return statsCharacterBase.statCharacter[i];
    //         }
    //     }
    //
    //     return null;
    // }
    //
    // protected virtual void SetupStart()
    // {
    //     ChangAnim(MyConstan.PLAYER_ANIM_IDLE);
    // }
    //
    // protected virtual void SetupUpdate()
    // {
    // }
    //
    // protected virtual void SetupFixedUpdate()
    // {
    // }
    //
    // #region Idle
    //
    // protected virtual void Idle()
    // {
    //     ChangeState(new IdleStateMachine());
    // }
    //
    // public virtual void StartIdle()
    // {
    //     eCharacterState = ECharacterState.IDLE;
    // }
    //
    // public virtual void ExcuteIdle()
    // {
    // }
    //
    // public virtual void ExitIdle()
    // {
    // }
    //
    // #endregion
    //
    // #region Move
    //
    // protected virtual void Move()
    // {
    //     ChangeState(new MoveStateMachine());
    // }
    //
    // public virtual void StartMove()
    // {
    //     eCharacterState = ECharacterState.MOVE;
    // }
    //
    // public virtual void ExcuteMove()
    // {
    // }
    //
    // public virtual void ExitMove()
    // {
    // }
    //
    // #endregion
    //
    // #region Move
    //
    // protected virtual void Attack()
    // {
    //     ChangeState(new MoveStateMachine());
    // }
    //
    // public virtual void StartAttack()
    // {
    //     eCharacterState = ECharacterState.ATTACK;
    // }
    //
    // public virtual void ExcuteAttack()
    // {
    // }
    //
    // public virtual void ExitAttack()
    // {
    // }
    //
    // #endregion
    //
    // #region Take damage
    //
    // public virtual void TakeDamage(CharacterController attacker)
    // {
    //     if (IsCanHit(attacker))
    //     {
    //         var damage = Random.Range(attacker.statCharacter.statCharacterATK.minATK,
    //             attacker.statCharacter.statCharacterATK.maxATK);
    //         damage = (damage * 2) / (damage + (statCharacter.statCharacterDMF.def -
    //                                            (statCharacter.statCharacterDMF.def *
    //                                             attacker.statCharacter.statCharacterATK.penetrate)));
    //         if (IsCriticalDamage(attacker))
    //         {
    //             damage = damage + (damage * attacker.statCharacter.statCharacterATK.criticalDamage);
    //         }
    //
    //         damage = damage + (damage * takeMoreDamage);
    //         damage = damage - (damage * statCharacter.statCharacterDMF.damageReduction);
    //         Debug.LogError("damage: " + damage);
    //         statCharacter.statCharacterDMF.HP -= damage;
    //         this.PostEvent(EventName.TAKE_DAMAGE, new object[] { attacker, this });
    //     }
    //     else
    //     {
    //         Debug.LogError("Ne damage");
    //     }
    // }
    //
    // protected virtual bool IsCriticalDamage(CharacterController attacker)
    // {
    //     var rand = Random.Range(1, 101);
    //     var percent = Mathf.RoundToInt(attacker.statCharacter.statCharacterATK.criticalRate);
    //     return percent >= rand;
    // }
    //
    // protected virtual bool IsCanHit(CharacterController attacker)
    // {
    //     var rand = Random.Range(1, 101);
    //     var percent = Mathf.RoundToInt(Mathf.Clamp(
    //         (100 - attacker.statCharacter.statCharacterATK.accurate) + statCharacter.statCharacterDMF.evasion, 0, 95));
    //     return rand > percent;
    // }
    //
    // #endregion
    //
    // //private void Move()
    // //{
    // //    if (directionMove.magnitude < 0.05f)
    // //    {
    // //        if (currentStateAnim != "idle")
    // //        {
    // //            currentStateAnim = "idle";
    // //            animatorCharacter.SetTrigger("idle");
    // //        }
    // //        myRig.velocity = Vector3.zero;
    // //    }
    // //    else
    // //    {
    // //        myRig.velocity = directionMove * statCharacter.statCharacterOther.MSPD;
    //
    // //        if (directionMove.magnitude < 0.6f)
    // //        {
    // //            if (currentStateAnim != "walk")
    // //            {
    // //                currentStateAnim = "walk";
    // //                animatorCharacter.SetTrigger("walk");
    // //            }
    // //        }
    // //        else
    // //        {
    // //            if (currentStateAnim != "run")
    // //            {
    // //                currentStateAnim = "run";
    // //                animatorCharacter.SetTrigger("run");
    // //            }
    // //        }
    // //    }
    //
    // //}
    //
    // //private void Rotate()
    // //{
    // //    if (directionMove.magnitude >= 0.05f)
    // //    {
    // //        var angle = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg;
    // //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * 10);
    // //    }
    // //}
    //
    // //private void Attack()
    // //{
    // //    animatorCharacter.SetTrigger("attack");
    // //}
    //
    // protected void ChangeState(IStateMachine stateMachine)
    // {
    //     if (currentStateMachine != null) currentStateMachine.OnExit(this);
    //     currentStateMachine = stateMachine;
    //     if (currentStateMachine != null) currentStateMachine.OnStart(this);
    // }
    //
    // public virtual void Idle()
    // {
    //     ChangAnim(MyConstan.PLAYER_ANIM_IDLE);
    // }
    //
    // public virtual void Move()
    // {
    //     ChangAnim(MyConstan.PLAYER_ANIM_RUN);
    // }
    //
    // public virtual void Attack()
    // {
    // }
    //
    // public void ChangAnim(string anim)
    // {
    //     if (anim != currentStateAnim)
    //     {
    //         animatorCharacter.ResetTrigger(currentStateAnim);
    //         currentStateAnim = anim;
    //         animatorCharacter.SetTrigger(currentStateAnim);
    //     }
    // }
}