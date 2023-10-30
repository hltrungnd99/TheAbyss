using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Weapon and attack

    public List<WeaponAsset> listWeaponInit;

    public IAttack iAttack;

    public List<CharacterController> listCharInRange = new();

    #endregion

    #region Component

    [SerializeField] protected Rigidbody myRig;

    #endregion

    [SerializeField] private float damage;
    [SerializeField] private float hp;
    public bool IsAlive => hp > 0 && eCharacterState != ECharacterState.DIE;

    public CharacterModel characterModel;

    public Vector3 DirectionMove => directionMove;
    public ECharacterState eCharacterState;
    public IStateMachine currentStateMachine;

    protected Vector3 directionMove = Vector3.zero;
    protected float minDisCharToTarget;

    private string currentStateAnim;

    public Collider colRecieveDamage;

    public CharacterController charTarget;
    public Transform transCharTarget;

    #region Range attack

    private CharacterController charInRange;

    public int countTargetCanAtk;

    #endregion

    private void Start()
    {
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

    protected virtual void SetupStart()
    {
        ChangeStateMachine(new IdleStateMachine());
        characterModel.OnInit(this);
    }

    protected virtual void SetupUpdate()
    {
        currentStateMachine?.OnExcute(this);
        SetCharTarget();

        if (charTarget)
        {
            transCharTarget = charTarget.transform;
            charTarget.ActiveTarget(true);
        }
    }

    protected virtual void SetCharTarget()
    {
        minDisCharToTarget = 99999f;
        if (listCharInRange.Count > 0 && eCharacterState != ECharacterState.ATTACK)
        {
            for (int i = 0; i < listCharInRange.Count; i++)
            {
                listCharInRange[i].ActiveTarget(false);
                var disntace = Vector3.Distance(transform.position, listCharInRange[i].transform.position);
                if (disntace < minDisCharToTarget)
                {
                    minDisCharToTarget = disntace;
                    charTarget = listCharInRange[i];
                }
            }
        }
        else if (listCharInRange.Count <= 0)
        {
            transCharTarget = null;
            charTarget = null;
        }
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

    public virtual void OnHitted(CharacterController characterController)
    {
        // normalAttack.OnHitted(this, new List<CharacterController>() { characterController });
    }

    #region state machine

    #region idle state

    public virtual void ExcuteIdle()
    {
        if (IsCanNormalAttack())
        {
            ChangeStateMachine(
                new AttackStateMachine(characterModel.weaponInChar.currentWeaponR));
        }
        else if (IsCanChaseTarget())
        {
            ChangeStateMachine(new ChaseStateMachine());
        }
    }

    #endregion

    #region move state

    public virtual void StartMove()
    {
    }

    public virtual void ExcuteMove()
    {
    }

    #endregion

    #region chase state

    public virtual void StartChase()
    {
    }

    public virtual void ExcuteChase()
    {
    }

    public virtual void ExitChase()
    {
    }

    #endregion

    #region attack state

    public virtual void StartAttack()
    {
    }

    #endregion

    #endregion

    public virtual void WarningAttack(Collider other)
    {
        charInRange = other.GetComponentInParent<CharacterController>();
        if (charInRange && !listCharInRange.Contains(charInRange))
        {
            listCharInRange.Add(charInRange);
        }
    }

    public virtual void CancelWarningAttack(Collider other)
    {
        if ((other.CompareTag(ConstTags.PLAYER_TAG) || other.CompareTag(ConstTags.ENEMY_TAG)) &&
            !other.CompareTag(gameObject.tag))
        {
            charInRange = other.GetComponentInParent<CharacterController>();
            if (charInRange && listCharInRange.Contains(charInRange))
            {
                charInRange.ActiveTarget(false);
                listCharInRange.Remove(charInRange);
            }
        }
    }

    public virtual bool IsCanChaseTarget()
    {
        return charTarget && charTarget.IsAlive;
    }

    public virtual bool IsCanNormalAttack()
    {
        return charTarget && charTarget.IsAlive && countTargetCanAtk > 0;
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
        colRecieveDamage.enabled = false;
        eCharacterState = ECharacterState.DIE;
    }

    public virtual void ActiveTarget(bool isActive)
    {
    }

    public void ChangeAnim(string anim)
    {
        if (anim != currentStateAnim)
        {
            if (!string.IsNullOrEmpty(currentStateAnim))
            {
                characterModel.animatorCharacter.ResetTrigger(currentStateAnim);
            }

            currentStateAnim = anim;
            if (!string.IsNullOrEmpty(currentStateAnim))
            {
                characterModel.animatorCharacter.SetTrigger(currentStateAnim);
            }
        }
    }

    public void ChangeStateMachine(IStateMachine nextState)
    {
        if (currentStateMachine != nextState)
        {
            currentStateMachine?.OnExit(this);
            currentStateMachine = nextState;
            currentStateMachine?.OnStart(this);
        }
    }
}