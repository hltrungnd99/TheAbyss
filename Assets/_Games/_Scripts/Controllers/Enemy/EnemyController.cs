using System.Collections;
using System.Collections.Generic;
using _Games._Scripts.Controllers.Player;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterController
{
    [SerializeField] protected NavMeshAgent navMeshEnemy;
    [SerializeField] protected GameObject objTarget;

    private List<PlayerController> listPlayerInZone = new List<PlayerController>();
    private Vector3 originPos;
    private bool isInFirstPos;

    protected override void SetupStart()
    {
        base.SetupStart();

        StartCoroutine(IEDelayCache());
    }

    private IEnumerator IEDelayCache()
    {
        yield return new WaitForSeconds(0.5f);

        originPos = transform.position;
    }

    public override void ActiveTarget(bool isActive)
    {
        objTarget.SetActive(isActive);
    }

    protected override void SetupUpdate()
    {
        base.SetupUpdate();

        if (!isInFirstPos && !IsCanChaseTarget() && eCharacterState != ECharacterState.ATTACK &&
            eCharacterState != ECharacterState.MOVE)
        {
            ChangeStateMachine(new IdleStateMachine());
        }
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
            navMeshEnemy.SetDestination(transCharTarget.position);

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
            for (int i = 0; i < listPlayerInZone.Count; i++)
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