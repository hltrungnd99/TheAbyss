using System;
using System.Collections.Generic;
using _Games._Scripts;
using _Games._Scripts.Controllers.Ability;
using UnityEngine;
using System;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected string myStatBase;
    [SerializeField] protected Rigidbody myRig;
    [SerializeField] protected Animator animatorCharacter;
<<<<<<< HEAD
    [SerializeField] protected NormalAttack normalAttack;
    [SerializeField] private float damage;
    [SerializeField] private float hp;
    [SerializeField] private Collider[] colAtks;

    [SerializeField] public CallbackAnim callbackAnim;

    protected Vector3 directionMove = Vector3.zero;
    public Vector3 DirectionMove => directionMove;

    protected bool isCanMove;
    protected ECharacterState eCharacterState;
=======
    [SerializeField] protected List<CharacterController> myTarget = new List<CharacterController>();

>>>>>>> origin/feature/quynhtv

    private string currentStateAnim;

    private void Start()
    {
<<<<<<< HEAD
=======
        // if set up data
        //statCharacter = new StatCharacter();
        //statCharacter.Clone(SetupTypeStat());

>>>>>>> origin/feature/quynhtv
        SetupStart();
    }

    private void Update()
    {
        SetupUpdate();
    }

    private void FixedUpdate()
    {
        SetupFixedUpdate();
    }

    private void OnDestroy()
    {
    }

    protected virtual void SetupOnDestroy()
    {
    }

    protected virtual void SetupStart()
    {
        ChangeAnim(ConstAnimParams.PLAYER_ANIM_IDLE);
    }

    protected virtual void SetupUpdate()
    {
    }

    protected virtual void SetupFixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        SetupTrigger(other);
    }

    protected virtual void SetupTrigger(Collider other)
    {
    }

    protected virtual void Move()
    {
        ChangeAnim(ConstAnimParams.PLAYER_ANIM_RUN);
        eCharacterState = ECharacterState.MOVE;
    }

    protected virtual void Idle()
    {
        ChangeAnim(ConstAnimParams.PLAYER_ANIM_IDLE);
        eCharacterState = ECharacterState.IDLE;
    }

    protected virtual void Attack<T1, T2>(T1 characterController, List<T2> lstEnemy = null)
        where T1 : CharacterController where T2 : CharacterController
    {
        eCharacterState = ECharacterState.ATTACK;
        normalAttack.Attack(characterController, lstEnemy);
    }

    public virtual void WarningAttack(Collider other)
    {
    }

    public virtual void CancelWarningAttack(Collider other)
    {
    }

    public virtual void Damage<T>(T characterHitted) where T : CharacterController
    {
        characterHitted.GetDamage(damage);
    }

    public virtual void GetDamage(float dam)
    {
        hp -= dam;
        if (hp <= 0)
        {
            Debug.LogError("die: " + gameObject.name);
            Dead();
        }
    }

    public virtual void Dead()
    {
        ChangeAnim(ConstAnimParams.PLAYER_ANIM_DIE);
    }

    public void ActiveColAtk(Component arg1, object[] arg2)
    {
        if (colAtks != null)
        {
            for (int i = 0; i < colAtks.Length; i++)
            {
                colAtks[i].enabled = true;
            }
        }
    }

    public void ChangeAnim(string anim)
    {
        if (anim != currentStateAnim)
        {
            animatorCharacter.ResetTrigger(currentStateAnim);
            currentStateAnim = anim;
            animatorCharacter.SetTrigger(currentStateAnim);
        }
    }
}