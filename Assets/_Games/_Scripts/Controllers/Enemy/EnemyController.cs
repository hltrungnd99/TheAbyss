using System.Collections;
using System.Collections.Generic;
using _Games._Scripts.Controllers.Player;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterController
{
    [SerializeField] protected NavMeshAgent navMeshEnemy;
    [SerializeField] protected GameObject objTarget;

    private List<PlayerController> listPlayerInZone = new();
    private bool isInFirstPos = true;
    public PoolType poolType;
    public Vector3 originPos;

    protected override void SetupAwake()
    {
        base.SetupAwake();

        this.RegisterEventListener(EventName.PLAYER_DEAD, EventDead);
    }

    protected override void SetupDestroy()
    {
        base.SetupDestroy();

        this.RegisterEventListener(EventName.PLAYER_DEAD, EventDead);
    }

    protected override void SetupStart()
    {
        base.SetupStart();

        // StartCoroutine(IEDelayCache());
    }

    public GameObject go;

    public IEnumerator IESetDestination(Vector3 pos)
    {
        navMeshEnemy.enabled = true;
        yield return new WaitUntil(() => gameObject.activeInHierarchy && navMeshEnemy.enabled);
        originPos = pos;
        go = new GameObject();
        go.transform.position = pos;
        navMeshEnemy.SetDestination(pos);
    }

    public void SetDestination(Vector3 pos)
    {
        navMeshEnemy.enabled = true;
        originPos = pos;

        navMeshEnemy.SetDestination(pos);
    }

    public override void ActiveTarget(bool isActive)
    {
        objTarget.SetActive(isActive);
    }

    protected override void SetupUpdate()
    {
        if (eCharacterState == ECharacterState.DIE) return;

        base.SetupUpdate();

        if (!isInFirstPos && !IsCanChaseTarget() && eCharacterState != ECharacterState.ATTACK &&
            eCharacterState != ECharacterState.MOVE)
        {
            ChangeStateMachine(new IdleStateMachine());
        }

        if (go && navMeshEnemy.enabled)
            navMeshEnemy.SetDestination(go.transform.position);
    }

    protected override void Dead()
    {
        base.Dead();

        this.PostEvent(EventName.ENEMY_DEAD, new object[] { this });
    }

    public override void ExcuteIdle()
    {
        if (!isInFirstPos && !IsCanChaseTarget())
        {
            ChangeStateMachine(new MoveStateMachine());
        }
        else
        {
            base.ExcuteIdle();
        }
    }

    public override void StartMove()
    {
        base.StartMove();

        isInFirstPos = false;
    }

    public override void ExcuteMove()
    {
        base.ExcuteMove();

        if (!isInFirstPos && !IsCanChaseTarget())
        {
            navMeshEnemy.enabled = true;
            navMeshEnemy.isStopped = false;
            navMeshEnemy.SetDestination(originPos);

            if (Vector3.Distance(originPos, transform.position) < 0.1f)
            {
                isInFirstPos = true;
                ChangeStateMachine(new IdleStateMachine());
            }
        }
        else if (IsCanChaseTarget())
        {
            ChangeStateMachine(new IdleStateMachine());
        }
    }

    public override void StartChase()
    {
        base.StartChase();

        isInFirstPos = false;
    }

    public override void ExcuteChase()
    {
        base.ExcuteChase();

        if (transCharTarget)
        {
            navMeshEnemy.enabled = true;
            navMeshEnemy.isStopped = false;
            var pos = transCharTarget.position;
            navMeshEnemy.SetDestination(pos);

            if (IsCanNormalAttack())
            {
                ChangeStateMachine(new IdleStateMachine());
            }
        }
        else
        {
            ChangeStateMachine(new IdleStateMachine());
        }
    }

    public override void ExitChase()
    {
        base.ExitChase();

        navMeshEnemy.isStopped = true;
        navMeshEnemy.enabled = false;
    }

    public override void StartAttack()
    {
        base.StartAttack();

        isInFirstPos = false;
    }

    public void AddPlayerInZone(PlayerController player)
    {
        if (!listPlayerInZone.Contains(player))
        {
            listPlayerInZone.Add(player);
        }
    }

    public void RemovePlayerInZone(PlayerController player)
    {
        if (listPlayerInZone.Contains(player))
        {
            listPlayerInZone.Remove(player);
        }
    }

    protected override void SetCharTarget()
    {
        base.SetCharTarget();

        if (listPlayerInZone.Count > 0 && eCharacterState != ECharacterState.ATTACK)
        {
            for (var i = 0; i < listPlayerInZone.Count; i++)
            {
                listPlayerInZone[i].ActiveTarget(false);
                var disntace = Vector3.Distance(transform.position, listPlayerInZone[i].transform.position);
                if (disntace < minDisCharToTarget)
                {
                    minDisCharToTarget = disntace;
                    charTarget = listPlayerInZone[i];
                }
            }
        }
    }
}